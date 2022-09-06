using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hospitality.Web.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }
    }
}