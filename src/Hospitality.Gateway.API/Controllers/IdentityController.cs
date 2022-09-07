using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private HttpClient _httpClient;
        public IdentityController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpPost]
        public async Task<IActionResult> CreateNewCheckupAsync(string email, string password)
            => await GetContentAsync(email, password, ""); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<IActionResult> GetContentAsync(string email, string password, string url)
        {
            object credentials = new {email, password};
            var jsonEmail = JsonConvert.SerializeObject(credentials);
            var content = new StringContent(jsonEmail, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
            // Chuj wie czy to zadziała
        }
    }
}
