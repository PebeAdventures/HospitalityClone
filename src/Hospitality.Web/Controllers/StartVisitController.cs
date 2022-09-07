using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Hospitality.Web.Controllers
{
    public class StartVisitController : Controller
    {
        public IActionResult StartVisit()
        {
            return View();
        }
    }
}
