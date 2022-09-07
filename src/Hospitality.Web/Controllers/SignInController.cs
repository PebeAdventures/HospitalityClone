using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hospitality.Web.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SingInModel singInData)
        {
            string login = singInData.login;
            string password = singInData.password;
            return RedirectToAction("StartVisit", "StartVisit", null);
        }
    }
}