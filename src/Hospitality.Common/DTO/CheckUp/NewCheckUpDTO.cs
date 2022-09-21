using Hospitality.Common.DTO.Examination;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.WebPages.Html;

namespace Hospitality.Common.DTO.CheckUp
{
    public class NewCheckUpDTO
    {
        public string Description { get; set; }
        public int IdPatient { get; set; }
        public int IdDoctor { get; set; }
        public string PeselOfPatient { get; set; }
        public SelectList Examinations { get; set; }
    }
}
