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
        [Route("Pesel")]
        public async Task<IActionResult> GetPatientByPeselAsync(string pesel)
        {
            var operationResult = await _service.GetPatientByPeselAsync(pesel);
            return Ok(operationResult);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDoctorViewDTO>> AddPatientAsync(PatientReceptionistViewDTO patientAddDTO)
        {
            await _service.AddPatientAsync(patientAddDTO);
            return Ok();
        }
    }
}
