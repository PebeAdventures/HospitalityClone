using Hospitality.Common.DTO.Identity;
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
        private readonly IConfiguration _configuration;

        public IdentityController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(Credentials credentials)
            => await GetContentAsync(credentials, _configuration["Paths:LogIn"]);

        private async Task<IActionResult> GetContentAsync(Credentials credentials, string url)
        {
            var jsonEmail = JsonConvert.SerializeObject(credentials);
            var content = new StringContent(jsonEmail, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null || response.StatusCode == System.Net.HttpStatusCode.NoContent) return NoContent();
            return Ok(await response.Content.ReadAsStringAsync());
        }
    }
}