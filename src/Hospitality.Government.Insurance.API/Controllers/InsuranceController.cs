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
        {
            var randomized = random.Next(0,2);
            if (randomized == 0) return Ok(false);
            return Ok(true);
        }
    }
}
