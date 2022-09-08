using System.ComponentModel.DataAnnotations;

namespace Hospitality.Web.Models
{
    public class PatientDataForStartVisit
    {
        [StringLength(15)]
        public string PatientPesel { get; set; }
    }
}
