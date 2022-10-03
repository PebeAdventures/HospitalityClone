using Hospitality.Common.Middlewares;

namespace Hospitality.CheckUp.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
            services.AddCors(options =>
            {
                
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7236/",
                            "https://localhost:7236/swagger/index.html")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });
        }
    }
}
