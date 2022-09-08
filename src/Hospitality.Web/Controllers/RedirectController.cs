using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Web.Controllers
{
    public class RedirectController : Controller
    {
       // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        //[HttpGet]
        //public IActionResult Redirect()
        //{
        //    return RedirectToAction("StartVisit", "StartVisit", null);
        //}


        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
        public IActionResult Redirect(string? role)
        {
            return RedirectToAction("Registration", "Registration", null);
        }
    }
}
