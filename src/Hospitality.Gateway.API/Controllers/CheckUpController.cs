using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckUpController : ControllerBase
    {
        private HttpClient _httpClient;
        public CheckUpController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpPost]
        public async Task<IActionResult> CreateNewCheckupAsync(object newCheckup)
            => await GetContentAsync(newCheckup, ""); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<IActionResult> GetContentAsync(object newCheckup, string url)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }
    }
}
