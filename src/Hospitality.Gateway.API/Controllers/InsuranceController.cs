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
        public InsuranceController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpPost]
        public async Task<IActionResult> CreateNewCheckupAsync(int id)
            => Ok(await GetContentAsync(id, "https://localhost:7101/api/Insurance")); // LINK DO UZUPEŁNIENIA !!! 
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
