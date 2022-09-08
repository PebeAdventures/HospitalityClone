using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hospitality.Web.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Registration(RegistrationPatientModel? model)
        {
            TempData["Name"] = model.name;
            //if (model.name == null) model.name = "";
            if (model.surname == null) model.surname = "";
            if (model.pesel == null) model.pesel = "";
            if (model.date == null) model.date = DateTime.Now;
            if (model.address == null) model.address = "";
            //if (model.phoneNumber == null) model.phoneNumber = "";
            //if (model.specialist == null) model.specialist = SpecialistEnum.none;
            if (model.isHealthInsurance == null) model.isHealthInsurance = "";
            return View(model);
        }

        [HttpPost]
        public IActionResult RegistrationPost(RegistrationPatientModel model)
        {
            string name = model.name;
            string surname = model.surname;
            string pesel = model.pesel;
            string address = model.address;
            string phoneNumber = model.phoneNumber;
            DateTime date = model.date;
            SpecialistEnum specialist = model.specialist;
            return RedirectToAction("Registration", "Registration", 
                new RegistrationPatientModel { name = model.name, surname = model.surname, pesel = model.pesel,
                                                date = model.date, address = model.address, phoneNumber = model.phoneNumber, 
                                                specialist = model.specialist, isHealthInsurance = ""});
            // return RedirectToAction("StartVisit", "StartVisit", null);
        }

        [HttpPost]
        public IActionResult checkHealthInsurance(RegistrationPatientModel model)
        {
            Random rnd = new Random();
            ViewData["isHealthInsurance"] = Convert.ToBoolean(rnd.Next(0, 1));
            model.isHealthInsurance = Convert.ToBoolean(rnd.Next(0, 1)).ToString();
            return RedirectToAction("Registration", "Registration",
                new RegistrationPatientModel
                {
                    name = model.name,
                    surname = model.surname,
                    pesel = model.pesel,
                    date = model.date,
                    address = model.address,
                    phoneNumber = model.phoneNumber,
                    isHealthInsurance = model.isHealthInsurance,
                    specialist = model.specialist
                });
        }
    }
}
