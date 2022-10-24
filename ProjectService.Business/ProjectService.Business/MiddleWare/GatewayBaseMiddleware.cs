using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.IO;
using ProjectService.Business.Core.Exceptions;
using ProjectService.Business.Services.Logging;

namespace ProjectService.Business.MiddleWare;

public class GatewayBaseMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GatewayRequestMiddleware> _logger; //niye GatewayRequestMiddleware type olaraq ILogger

    public GatewayBaseMiddleware(RequestDelegate next, ILogger<GatewayRequestMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext context, ILoggingService loggingService)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
            _logger.LogError(exception, exception.Message);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode httpCode;
        int code;
        string message = string.Empty;

        switch (exception)
        {
            case NotFoundException:
                httpCode = HttpStatusCode.NotFound;
                code = 404;
                _logger.LogInformation("Not found request.");
                break;

            case DefaultValidationException:
                httpCode = HttpStatusCode.UnprocessableEntity;
                code = 422;
                _logger.LogInformation("Not valid request.");
                break;

            case QuotaExceededException ex:
                code = ex.Code;
                // message = ValidationConstants.ValidationMessages[ex.Code];
                httpCode = HttpStatusCode.Unauthorized;
                _logger.LogInformation("Quota exceeded.");
                break;

            case UnauthorizedException ex:
                code = ex.Code;
                // message = ValidationConstants.ValidationMessages[ex.Code];
                httpCode = HttpStatusCode.Unauthorized;
                _logger.LogInformation("Unauthorized request.");
                break;

            case BadRequestException:
                code = 400;
                httpCode = HttpStatusCode.BadRequest;
                _logger.LogInformation("Bad request.");
                break;

            default:
                code = 500;
                httpCode = HttpStatusCode.InternalServerError;
                message = exception.Message;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int) httpCode;


        // var responseModel = new GatewayErrorResponseModel
        // {
        //     Status = new CodeMessageResponseModel
        //     {
        //         Code = context.Response.StatusCode,
        //         Message = "Uğursuz əməliyyat."
        //     },
        //     Errors = new List<CodeMessageResponseModel>
        //     {
        //         new()
        //         {
        //             Code = code,
        //             Message = message
        //         }
        //     }
        // };

        // var data = JsonConvert.SerializeObject(responseModel, new JsonSerializerSettings
        // {
        //     ContractResolver = new CamelCasePropertyNamesContractResolver()
        // });

        // await context.Response.WriteAsync(data);
    }

}