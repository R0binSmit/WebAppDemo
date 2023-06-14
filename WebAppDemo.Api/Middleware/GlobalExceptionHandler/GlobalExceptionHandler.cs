using Newtonsoft.Json;
using System.Net;
using WebAppDemo.Api.Exceptions;

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

        var message = new Message
        {
            MessageType = MessageType.Error,
            Title = exception.GetType().ToString(),
            Description = exception.Message,
        };

        _logger.LogError(exception, message.Description);
        context.Response.StatusCode = IdentifyHttpStatusCode(exception);
        return context.Response.WriteAsync(JsonConvert.SerializeObject(message));
    }

    private int IdentifyHttpStatusCode(Exception exception)
    {
        switch (exception) 
        {
            case ArgumentException argumentException:
                return (int)HttpStatusCode.BadRequest;
            case NotFoundException notFoundException:
                return (int)HttpStatusCode.NotFound;
            default:
                return (int)HttpStatusCode.InternalServerError;

        }
    }
}
