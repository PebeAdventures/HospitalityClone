using Hospitality.Common.DTO.Patient;

namespace Hospitality.Web.Models
{
    public class AppointDoctorToPatientModel
    {
        public string PatientPesel { get; set; }
        public SpecialistEnum Specialist { get; set; }

    }
}
