using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public InsuranceController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> CheckInsurance(int id)
            => Ok(await GetContentAsync(id, _configuration["Paths:CheckInsurance"]));

        private async Task<HttpResponseMessage> GetContentAsync(int id, string url)
        {
            var json = JsonConvert.SerializeObject(id);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return response;
            return response;
        }
    }
}