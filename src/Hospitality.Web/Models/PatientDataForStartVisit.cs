using System.ComponentModel.DataAnnotations;

namespace Hospitality.Web.Models
{
    public class PatientDataCheckUpViewModel
    {
        [StringLength(15)]
        public string PatientPesel { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public int DoctorId { get; set; }
        public string ChosenExamination { get; set; }
        public int ChosenExaminationId { get; set; }
        public List<string> AvailableExaminations { get; set; }
    }
}
