using Hospitality.Common.DTO.Identity;
using Hospitality.Identity.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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
        public async Task<IActionResult> Login(Credentials credentials)
        {
            var jwt = await LogInService.Login(credentials.email, credentials.password);
            if (jwt == null) return NoContent();
            return Ok(jwt);
        }
    }
}
