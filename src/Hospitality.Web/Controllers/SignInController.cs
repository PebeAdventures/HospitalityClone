using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Hospitality.Web.Controllers
{
    public class SignInController : Controller
    {
        [HttpGet]
        public IActionResult SignIn(bool? result)
        {
            if (result == false)
            {
                ViewBag.Show = "show";

            }

            return View();
        }
        [HttpPost]
        public IActionResult SignIn(SingInModel singInData)
        {
            string login = singInData.login;
            string password = singInData.password;
            ViewBag.Show = "show";
            if (password != "aaa")
            {
               
                return RedirectToAction("SignIn", "SignIn", new { result  = false});
            } else
            {
                return RedirectToAction("StartVisit", "StartVisit", null);

            }
        }
    }
}