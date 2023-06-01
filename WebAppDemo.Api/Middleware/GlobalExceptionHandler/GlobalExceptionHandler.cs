using Newtonsoft.Json;
using System.Net;

namespace WebAppDemo.Api.Middleware.GlobalExceptionHandler;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        RequestDelegate next,
        ILogger<GlobalExceptionHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        var error = new Error
        {
            Message = exception.Message,
            Type = exception.GetType().ToString()
        };

        _logger.LogError(exception, error.Message);
        context.Response.StatusCode = IdentifyHttpStatusCode(exception);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(error));
    }

    private int IdentifyHttpStatusCode(Exception exception)
    {
        switch (exception) 
        {
            case ArgumentException argumentException:
                return (int)HttpStatusCode.BadRequest;
            default:
                return (int)HttpStatusCode.InternalServerError;

        }
    }
}
