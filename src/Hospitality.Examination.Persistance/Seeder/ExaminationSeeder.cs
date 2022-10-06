using Hospitality.Examination.Domain.Entities;
using Hospitality.Examination.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Hospitality.Examination.Persistance.Seeder
{
    public static class ExaminationSeeder
    {
        public static void SeedDatabase(this ModelBuilder builder)
        {
            List<ExaminationInfo> examinationInfos = new();
            List<ExaminationType> examinationTypes = new();


            examinationInfos.Add(new ExaminationInfo()
            {
                Id = 1,
                PatientId = 1,
                Description = "Checking if your hearing is good",
                ExaminationTypeId = 1,
                Status = (ExaminationStatus)1
            });
            examinationInfos.Add(new ExaminationInfo()
            {
                Id = 2,
                PatientId = 2,
                Description = "Checking the teeth",
                ExaminationTypeId = 2,
                Status = (ExaminationStatus)1
            });
            examinationInfos.Add(new ExaminationInfo()
            {
                Id = 3,
                PatientId = 3,
                Description = "Examination of the musculoskeletal system",
                ExaminationTypeId = 3,
                Status = (ExaminationStatus)2
            });
            examinationInfos.Add(new ExaminationInfo()
            {
                Id = 4,
                PatientId = 4,
                Description = "Renal function test",
                ExaminationTypeId = 4,
                Status = (ExaminationStatus)2
            });


            examinationTypes.Add(new ExaminationType()
            {
                Id = 1,
                Name = "USG kolana",
                Duration = new TimeSpan(0, 0, 8)
            });

            examinationTypes.Add(new ExaminationType()
            {
                Id = 2,
                Name = "USG jamy brzusznej",
                Duration = new TimeSpan(0, 0, 10)
            });
            examinationTypes.Add(new ExaminationType()
            {
                Id = 3,
                Name = "RTG głowy",
                Duration = new TimeSpan(0, 0, 7)
            });
            examinationTypes.Add(new ExaminationType()
            {
                Id = 4,
                Name = "RTG celowane na ząb obrotnika",
                Duration = new TimeSpan(0, 0, 6)
            });

            examinationTypes.Add(new ExaminationType()
            {
                Id = 5,
                Name = "RTG styczne czaszki",
                Duration = new TimeSpan(0, 0, 6)
            });

            examinationTypes.Add(new ExaminationType()
            {
                Id = 6,
                Name = "Leczenie kanałowe zębów",
                Duration = new TimeSpan(0, 0, 6)
            });

            examinationTypes.Add(new ExaminationType()
            {
                Id = 7,
                Name = "Badanie kału na pasożyty",
                Duration = new TimeSpan(0, 0, 8)
            });
            examinationTypes.Add(new ExaminationType()
            {
                Id = 8,
                Name = "Cytologia płynna",
                Duration = new TimeSpan(0, 0, 10)
            });
            examinationTypes.Add(new ExaminationType()
            {
                Id = 9,
                Name = "Echo serca",
                Duration = new TimeSpan(0, 0, 7)
            });
            examinationTypes.Add(new ExaminationType()
            {
                Id = 10,
                Name = "Gastroskopia",
                Duration = new TimeSpan(0, 0, 6)
            });
            // builder.Entity<ExaminationInfo>().HasData(examinationInfos);
            builder.Entity<ExaminationType>().HasData(examinationTypes);
        }
    }
}
