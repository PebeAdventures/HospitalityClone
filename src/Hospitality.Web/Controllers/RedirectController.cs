﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Web.Controllers
{
    public class RedirectController : Controller
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
        [HttpGet]
        public IActionResult Redirect(string? role)

            => RedirectToAction("Registration", "Registration", null);
    }
}
