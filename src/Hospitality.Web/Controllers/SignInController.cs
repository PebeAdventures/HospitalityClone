using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Hospitality.Common.DTO.Identity;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;

namespace Hospitality.Web.Controllers
{

    public class SignInController : Controller
    {

        private HttpClient _httpClient;
        public SignInController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

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
            {
                ViewBag.Show = "show";
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(Credentials credentials)
        {
            ViewBag.Show = "show";

            var jsonCredentials = JsonConvert.SerializeObject(credentials);
            var content = new StringContent(jsonCredentials, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7236/api/Identity", content);
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