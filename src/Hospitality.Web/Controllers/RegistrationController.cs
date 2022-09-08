using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hospitality.Web.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registration(RegistrationPatientModel model)
        {
            string name = model.name;
            string surname = model.surname;
            string pesel = model.pesel;
            string address = model.address;
            string phoneNumber = model.phoneNumber;
            DateTime date = model.date;
            SpecialistEnum specialist = model.specialist;
            return View();
        }

        [HttpPost]
        public IActionResult checkHealthInsurance()
        {
            Random rnd = new Random();
            ViewData["isHealthInsurance"] = Convert.ToBoolean(rnd.Next(0, 1));
            return View("Registration", "Registration");
        }
    }
}
