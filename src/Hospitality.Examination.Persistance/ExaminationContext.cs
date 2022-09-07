using Hospitality.Examination.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Hospitality.Examination.API.Model
{
    public class ExaminationContext : DbContext
    {
        public ExaminationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ExaminationInfo> Examinations { get; set; }
        public DbSet<ExaminationType> ExaminationTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExaminationType>()
                .Property(s => s.Duration)
                .HasConversion(new TimeSpanToTicksConverter());
        }
    }
}