using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Temperature;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientTemperatureController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PatientTemperatureController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpGet("AllPatientTemperatures")]
        public async Task<IActionResult> AllPatientTemperatures(string patientId)
           => Ok(await _httpClient.GetStringAsync(_configuration["Paths:PatientTemperaturesList"] + patientId));


        [HttpPost("AddPatientTemperature")]
        public async Task<IActionResult> AddPatientTemperature(NewPatientTemperatureDTO newPatientTemperatureDTO)
         => Ok(await GetContentAsync(newPatientTemperatureDTO, _configuration["Paths:AddPatientTemperature"]));

        private async Task<HttpResponseMessage> GetContentAsync(NewPatientTemperatureDTO newPatientTemperatureDTO, string url)
        {
            var json = JsonConvert.SerializeObject(newPatientTemperatureDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            return response;
        }


    }
}
