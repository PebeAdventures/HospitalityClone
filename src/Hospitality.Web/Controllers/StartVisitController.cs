using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class StartVisitController : Controller
    {
        [HttpGet]
        public IActionResult StartVisit()
            => View();

        [HttpPost]
        public IActionResult StartVisit(PatientDataForStartVisit model)
            => RedirectToAction("CheckUp", "CheckUp", model);
    }
}
