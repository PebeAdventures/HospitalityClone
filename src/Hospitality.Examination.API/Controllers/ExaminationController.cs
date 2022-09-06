using Hospitality.Examination.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hospitality.Examination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationService _examinationService;

        public ExaminationController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExaminationTypes() => Ok(await _examinationService.GetAllAvailableExaminationTypesAsync());
    }
}