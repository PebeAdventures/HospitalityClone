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
        [Route("{pesel}")]
        public async Task<IActionResult> GetPatientByPeselAsync(string pesel)
        {
            var operationResult = await _service.GetPatientByPeselAsync(pesel);
            return Ok(operationResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddPatientAsync(PatientReceptionistViewDTO patientAddDTO)
        {
            PatientDoctorViewDTO? operationResult = await _service.AddPatientAsync(patientAddDTO);
            if (operationResult == null)
            {
                return BadRequest("Material not added");
            }
            return Ok(operationResult);
        }
    }
}
