using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class StartVisitController : Controller
    {
        [HttpGet]
        public IActionResult StartVisit()
            => View();

        [HttpPost]
        public IActionResult StartVisit(PatientDataCheckUpViewModel model)
            => RedirectToAction("CheckUp", "CheckUp", model);
    }
}
