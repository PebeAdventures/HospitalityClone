using System.ComponentModel.DataAnnotations;

namespace Hospitality.Web.Models
{
    public class RegistrationPatientModel
    {
        [StringLength(20)]

        public string name { get; set; }
        [StringLength(20)]
        public string surname { get; set; }
        [StringLength(15)]
        public string pesel { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime date { get; set; }
        [StringLength(20)]
        public string address { get; set; }
        [StringLength(20)]
        public string? phoneNumber { get; set; }

        public SpecialistEnum specialist { get; set; }
        public bool isHealthInsurance { get; set; }
    }
}
