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

        public CheckUpController(ICheckUpService checkUpService)
        {
            _checkUpService = checkUpService;
        }
    }
}