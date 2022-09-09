using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hospitality.Common.DTO.CheckUp;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult Registration(bool? result)
        {
            if (result == false) ViewBag.Invalid = "invalid";
            if (result == true) ViewBag.Invalid = "valid";

            return View();
        }

        [HttpPost]
        public IActionResult RegistrationPost(RegistrationPatientModel model)
        {
            if ((model.name == null) || model.surname == null || model.pesel == null || model.address == null || model.phoneNumber == null || model.date == null || model.specialist == null)
            {
                return RedirectToAction("Registration", "Registration", new { result = false });
            }
            string isHealthInsurance = "true";

            return RedirectToAction("Registration", "Registration", new { result = true });

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
