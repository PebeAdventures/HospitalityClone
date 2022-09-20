using Hospitality.Common.DTO.Examination;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class ExaminationController : Controller
    {
        private List<ExaminationClass> examinations;
        private string pesel;

        [HttpPost]
        public IActionResult Examination()
        {
            Request.Form["patientPesel"].First();
            examinations = new List<ExaminationClass>() {
               new ExaminationClass(){Name="Badanie 1", Description="Bolesne i nie skuteczne badanie", Cost=100, Duration = "dlugo"},
               new ExaminationClass(){Name="Badanie 2", Description="Bolesne i nie skuteczne badanie", Cost=100, Duration = "dlugo"},
            };
            return View(examinations);
        }

        [HttpGet]
        public IActionResult BackToCheckUp()
        {
            PatientDataForStartVisit patientDataForStartVisit = new PatientDataForStartVisit();
            patientDataForStartVisit.PatientPesel = pesel;
            return RedirectToAction("CheckUp", "CheckUp", patientDataForStartVisit);
        }


    }
}
