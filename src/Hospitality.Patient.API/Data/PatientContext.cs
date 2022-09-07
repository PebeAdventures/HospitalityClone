using Microsoft.EntityFrameworkCore;

namespace Hospitality.Patient.API.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
            : base(options) { }

        public DbSet<HospitalPatient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=PatientDB;Integrated Security=True");
        }
    }
}