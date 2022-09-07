namespace Hospitality.Patient.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void SetUpDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var patientDBconnectionString = configuration["ConnectionStrings:PatientDB"];
            services.AddSqlServer<PatientContext>(patientDBconnectionString);
        }
    }
}
