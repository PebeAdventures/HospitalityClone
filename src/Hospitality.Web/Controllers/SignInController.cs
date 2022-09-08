using Hospitality.Web.Models;
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




            var jsonEmail = JsonConvert.SerializeObject(credentials);
            var content = new StringContent(jsonEmail, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7236/api/Identity", content);
            if (!response.IsSuccessStatusCode || response is null)
            {
                return RedirectToAction("SignIn", "SignIn", new { result = false });

            } else
            {
                return RedirectToAction("StartVisit", "StartVisit", null);

            }
            // return StatusCode(404);
            // return StatusCode(204);

            HttpContext.Session.SetString("token", await response.Content.ReadAsStringAsync());








            //if (password != "aaa")
            //{
               
            //    return RedirectToAction("SignIn", "SignIn", new { result  = false});
            //} else
            //{
            //    return RedirectToAction("StartVisit", "StartVisit", null);

            //}



            //HttpContext.Session.SetString("token", await response.Content.ReadAsStringAsync()); - kod zapisujący JWT w Sesji 
        }
    }
}