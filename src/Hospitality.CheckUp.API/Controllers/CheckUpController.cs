using Hospitality.CheckUp.API.Service.Interface;
using Hospitality.Common.DTO.CheckUp;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospitality.CheckUp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUpController : ControllerBase
    {

        private readonly ICheckUpService _checkUpService;
        private readonly HttpClient _httpClient;
        public CheckUpController(ICheckUpService checkUpService, HttpClient httpClient)
        {
            _checkUpService = checkUpService;
            _httpClient = httpClient;
        }



        // POST api/<CheckUpController>
        [HttpPost]
        public async Task<ActionResult<NewCheckUpDTO>> AddNewCheckUp([FromBody] NewCheckUpDTO newCheckUpDTO)
        {
            var x = _checkUpService.AddNewCheckUp(newCheckUpDTO);
            return Ok(x);
        }

    }
}
