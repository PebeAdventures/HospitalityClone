using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecondExam.Services.Services.Auth;

namespace Hospitality.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private LogInService LogInService;
        public IdentityController(LogInService logInService)
            => LogInService = logInService;

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
            => Ok(LogInService.Login(email, password));
    }
}
