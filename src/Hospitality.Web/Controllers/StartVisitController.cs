using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospitality.Web.Controllers
{
    public class StartVisitController : Controller
    {

        [HttpGet]
        public IActionResult StartVisit()
        {
            return View();
        }
        [HttpPost]

        public IActionResult StartVisit(PatientDataForStartVisit model)
        {
            string pesel = model.PatientPesel;

            return RedirectToAction("CheckUp", "CheckUp", new PatientDataForStartVisit { PatientPesel  = model.PatientPesel});
        }


    }
}
