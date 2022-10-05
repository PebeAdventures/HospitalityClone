using Hospitality.Common.DTO.Patient;
using System.ComponentModel.DataAnnotations;

namespace Hospitality.Web.Models
{
    public class AppointDoctorToPatientModel
    {
        [MinLength(11), MaxLength(11)]
        public string PatientPesel { get; set; }
        public SpecialistEnum Specialist { get; set; }

    }
}
