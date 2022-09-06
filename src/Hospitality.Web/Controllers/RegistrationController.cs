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
    }
}
