using Hospitality.Common.DTO.Examination;
using Hospitality.Common.DTO.Temperature;
using Hospitality.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class TemperatureController : Controller
    {
        private HttpClient _httpClient;
        private List<PatientTemperaturesViewDTO> patientTemperaturesViewDTO;
        private ITemperatureService _temperatureService;

        public TemperatureController(IHttpClientFactory httpClientFactory, ITemperatureService temperatureService)
        {
            _httpClient = httpClientFactory.CreateClient();
            patientTemperaturesViewDTO = new List<PatientTemperaturesViewDTO>();
            _temperatureService = temperatureService;
        }


        [HttpPost]
        public async Task<IActionResult> Temperature(string patientId)
        {
            var patientTemperatures = await _temperatureService.GetPatientTemperatures(patientId, HttpContext.Session.GetString("token"));
            if (patientTemperatures != null)
            {
                return View(patientTemperatures);
            }
            patientTemperatures = new List<PatientTemperaturesViewDTO>() { new PatientTemperaturesViewDTO() { PatientId = patientId, Temperature = 0, MeasurementDate = DateTime.Now } };
            return View(patientTemperatures);
        }
    }
}
