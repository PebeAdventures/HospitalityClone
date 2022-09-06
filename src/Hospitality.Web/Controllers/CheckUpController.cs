using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospitality.Web.Controllers
{
    public class CheckUpController : Controller
    {
        public IActionResult CheckUp()
        {
            return View();
        }
    }
}
