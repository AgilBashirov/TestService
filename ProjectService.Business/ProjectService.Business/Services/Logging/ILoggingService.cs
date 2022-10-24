using Microsoft.AspNetCore.Http;

namespace ProjectService.Business.Services.Logging;

public interface ILoggingService
{
    Task<RequestLog> SaveRequestLog(HttpRequest request);
    Task SaveResponseLog(HttpResponse response, RequestLog requestLog);
}

public class RequestLog
{
}