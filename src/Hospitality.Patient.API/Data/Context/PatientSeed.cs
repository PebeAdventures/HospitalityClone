namespace Hospitality.Patient.API.Data.Context
{
    public static class PatientSeed
    {
        public static void SeedPatientDb(this ModelBuilder builder)
        {
            List<HospitalPatient> patients = new();
            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 5,
                PatientName = "Aniela",
                PatientSurname = "Nowak",
                PatientPesel = "99112234543",
                BirthDate = new DateTime(1999, 11, 22),
                Address = "Wrzosowa",
                Email = "aniela.nowak@gmail.com",
                PhoneNumber = "213769420",
                IsInsured = true,
            }); 
            
            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 6,
                PatientName = "Ania",
                PatientSurname = "Okrasa",
                PatientPesel = "98112234543",
                BirthDate = new DateTime(1998, 11, 22),
                Address = "Jaworowa",
                Email = "ania.okrasa@gmail.com",
                PhoneNumber = "123456456",
                IsInsured = true,
            }); 

            patients.Add(new HospitalPatient()
            {
                HospitalPatientId = 7,
                PatientName = "Michał",
                PatientSurname = "Jakos",
                PatientPesel = "97112234543",
                BirthDate = new DateTime(1997, 11, 22),
                Address = "Fiołkowa",
                Email = "michal.jakos@gmail.com",
                PhoneNumber = "456789123",
                IsInsured = true,
            }); 

            builder.Entity<HospitalPatient>().HasData(patients);
        }
    }
}
