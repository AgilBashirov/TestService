using Microsoft.AspNetCore.Http;

namespace ProjectService.Business.MiddleWare;

public class TestMiddleware
{
    private readonly RequestDelegate _next;

    public TestMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        
    }
}