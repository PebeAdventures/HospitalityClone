using Hospitality.CheckUp.API.Middlewares;

namespace Hospitality.CheckUp.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<LogHandlerMiddleware>();
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
