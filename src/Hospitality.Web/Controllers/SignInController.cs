using Microsoft.AspNetCore.Mvc;
using Hospitality.Common.DTO.Identity;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace Hospitality.Web.Controllers
{
    public class SignInController : Controller
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public SignInController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }
        private async Task<IActionResult> GetContentAsync(object newCheckup, string url)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var token = HttpContext.Session.GetString("token");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }

        [HttpGet]
        public IActionResult SignIn(bool? result)
        {
            if (result == false)
                ViewBag.Show = "show";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Credentials credentials)
        {
            ViewBag.Show = "show";

            var jsonCredentials = JsonConvert.SerializeObject(credentials);
            var content = new StringContent(jsonCredentials, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(_configuration["Paths:SignIn"], content);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return RedirectToAction("SignIn", "SignIn", new { result = false });
            }
            if (response.IsSuccessStatusCode && response.Content is not null)
            {
                var token = await response.Content.ReadAsStringAsync();
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("token", token);
                return RedirectToAction("Index", "Home", null);
            } 
            else
            {
                return RedirectToAction("Index", "Home", null);
            }
        }
    }
}