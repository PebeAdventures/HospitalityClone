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
        public IdentityController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpPost]
        public async Task<IActionResult> LogIn(Credentials credentials)
            => await GetContentAsync(credentials, "https://localhost:7272/api/Identity"); // LINK DO UZUPEŁNIENIA !!! 
        private async Task<IActionResult> GetContentAsync(Credentials credentials, string url)
        {
            var jsonEmail = JsonConvert.SerializeObject(credentials);
            var content = new StringContent(jsonEmail, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return NoContent();
            return Ok(response);
        }
    }
}
