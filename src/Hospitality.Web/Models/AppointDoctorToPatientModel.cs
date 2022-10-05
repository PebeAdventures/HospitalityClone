using Hospitality.Common.DTO.Patient;
using System.ComponentModel.DataAnnotations;

namespace Hospitality.Web.Models
{
    public class AppointDoctorToPatientModel
    {
        public string PatientPesel { get; set; }
        public SpecialistEnum Specialist { get; set; }

    }
}
