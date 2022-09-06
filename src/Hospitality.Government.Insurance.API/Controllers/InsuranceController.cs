using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Government.Insurance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private Random random;
        public InsuranceController()
            => random = new Random();

        [HttpPost]
        public async Task<IActionResult> CheckIfIsured(int idOfPerson)
            => Ok(random.Next(0, 1));
    }
}
