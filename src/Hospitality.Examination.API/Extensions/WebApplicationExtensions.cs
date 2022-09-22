using Hospitality.Examination.API.Middlewares;

namespace Hospitality.Examination.API.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void UseCustomMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
