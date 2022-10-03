using Hospitality.Common.Middlewares;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Persistance.Repositories;

namespace Hospitality.Examination.API.Extensions
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

        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IExaminationRepository, ExaminationRepository>();
            services.AddTransient<IExaminationTypesRepository, ExaminationTypesRepository>();


        }
    }
}
