namespace Hospitality.Patient.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;
        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetPatientByIdAsync(int id)
        {
            var operationResult = await _service.GetPatientByIdDoctorViewAsync(id);
            return Ok();
        }

        //[HttpPost]
        //public async Task<IActionResult> AddPatientAsync(PatientReceptionistViewDTO patientAddDTO)
        //{
        //    return Created();
        //}
    }
}
