namespace Hospitality.Patient.API.Data.Context
{
    public static class PatientSeed
    {
        public static void SeedPatientDb(this ModelBuilder builder)
        {
            List<HospitalPatient> patients = new();
            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 1,
                PatientName = "Aniela",
                PatientSurname = "Nowak",
                PatientPesel = "99112234543",
                BirthDate = new DateTime(1999, 11, 22),
                Address = "Wrzosowa",
                Email = "aniela.nowak@gmail.com",
                PhoneNumber = "213769420",
                IsInsured = true,
            }); ;
            builder.Entity<HospitalPatient>().HasData(patients);
        }
    }
}
