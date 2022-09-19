using Hospitality.Common.Models.Exceptions;
using System.Net;

namespace Hospitality.CheckUp.API.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try { await next.Invoke(context); }
            catch (ResourceNotFoundException resourceNotFoundException)
            {
                await HandleExceptionAsync(context, resourceNotFoundException, HttpStatusCode.NotFound).ConfigureAwait(false);
            }

            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception, HttpStatusCode.InternalServerError).ConfigureAwait(false);

            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, HttpStatusCode internalServerError)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)internalServerError;
            return context.Response.WriteAsJsonAsync(new { Error = exception.Message });
        }
    }
}
