using Hospitality.CheckUp.API.Middlewares;

namespace Hospitality.CheckUp.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<ExceptionHandlerMiddleware>();
        }
        public static void AddCustomCors(this IServiceCollection services)
        {
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
