using Hospitality.Common.Middlewares;
using Hospitality.Examination.Application.Contracts.Persistence;
using Hospitality.Examination.Application.Mapper.Profiles;
using Hospitality.Examination.Application.Services;
using Hospitality.Examination.Persistance.Repositories;
using Hospitality.Examination.RabbitMQ;

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

        public static void AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IExaminationRepository, ExaminationRepository>();
            services.AddTransient<IExaminationTypesRepository, ExaminationTypesRepository>();
            services.AddTransient<IUpdateExamination, UpdateExamination>();
            services.AddTransient<IRabbitMqService, RabbitMQPublisher>();
            services.AddCustomCors();
            services.AddHostedService<RabbitMQConsumer>();
            services.AddHealthChecks().AddSqlServer(configuration.GetValue<string>("EXAMINATION_SQL_CONNECTONSTRING"));
        }
    }
}