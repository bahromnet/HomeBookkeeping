using Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HomeBookkeeping.Middelwares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;
        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                await HandleException(httpContext, HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        public async ValueTask<ActionResult> HandleException(HttpContext httpContext, HttpStatusCode httpStatusCode, string message)
        {
            _logger.LogCritical(message);
            HttpResponse response = httpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            var error = new
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            return await Task.FromResult(new BadRequestObjectResult(error));

        }
    }


    public static class GlobalExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }

}
