﻿

namespace Hospitality.Patient.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IBaseRepository<HospitalPatient>, BaseRepository<HospitalPatient>>();
            services.AddScoped<IPatientService, PatientService>();
        }

    }
}
