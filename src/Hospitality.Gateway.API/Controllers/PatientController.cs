using Hospitality.Common.DTO.Patient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private HttpClient _httpClient;
        public PatientController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> GetPatientByPeselAsync(string pesel)
            => Ok(await _httpClient.GetStringAsync($"https://localhost:7043/api/Patient/Pesel?pesel={pesel}"));// LINK DO UZUPEŁNIENIA !!! 

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Receptionist")]
        [HttpPost]
        public async Task<IActionResult> RegisterNewPatientAsync(PatientReceptionistViewDTO newPatient)
            => await GetContentAsync(newPatient, "https://localhost:7043/api/Patient"); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<IActionResult> GetContentAsync(object newPatient, string url)
        {
            var json = JsonConvert.SerializeObject(newPatient);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }
    }
}
