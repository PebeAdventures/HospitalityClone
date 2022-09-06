using Hospitality.Identity.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Identity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private ILogInService LogInService;
        public IdentityController(ILogInService logInService)
            => LogInService = logInService;

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
            => Ok(await LogInService.Login(email, password));
    }
}
