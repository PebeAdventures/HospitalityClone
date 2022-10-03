

using Hospitality.Patient.API.Middlewares;

namespace Hospitality.Patient.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
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

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ExceptionHandlerMiddleware>();
        }

    }
}
