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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class StartVisitController : Controller
    {

        [HttpGet]
        public IActionResult StartVisit()
        {
            return View();
        }
        [HttpPost]

        public IActionResult StartVisit(PatientDataForStartVisit model)
            => RedirectToAction("CheckUp", "CheckUp", model.PatientPesel);

    }
}
