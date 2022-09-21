using Hospitality.Common.DTO.Examination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ExaminationController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExaminationById(int id)
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetExaminationById"] + id));

        [HttpGet("TypesOfExaminations")]
        public async Task<IActionResult> GetListOfTypesExaminationAsync()
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetExaminationTypes"]));

        [HttpGet("PatientExaminationsResults")]
        public async Task<IActionResult> GetCurrentPatientExaminationsResultsAsync(int id)
            => Ok(await _httpClient.GetStringAsync(_configuration["Paths:GetPatientResult"] + id));

        [HttpPost]
        public async Task<IActionResult> AddNewExaminationAsync(CreateExaminationDto newExamination)
            => await GetContent(newExamination, _configuration["Paths:AddNewExamination"]);

        private async Task<IActionResult> GetContent(object newExamination, string url)
        {
            var json = JsonConvert.SerializeObject(newExamination);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }
    }
}