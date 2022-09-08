using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Hospitality.Common.DTO.Identity;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Hospitality.Web.Controllers
{
    public class SignOutController : Controller
    {
        [HttpGet]
        public IActionResult SignOut()
        {
            HttpContext.Session.SetString("token", "");
            return RedirectToAction("SignIn", "SignIn", null);
        }
    }
}
