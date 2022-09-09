using Hospitality.Common.DTO.CheckUp;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]

    public class CheckUpController : Controller
    {
        private int pesel;
        private HttpClient _httpClient;
        public CheckUpController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();
        
        [HttpGet]
        public IActionResult CheckUp(string peselInString)
        {
            TempData["pesel"] = peselInString;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            // dopisać request do patient api o Id pacjęta
            //newCheckUpDTO.IdPatient = ;
            newCheckUpDTO.IdPatient = 1; // - to do zmiany
            if (!ModelState.IsValid)
            {
                return View(newCheckUpDTO);
            }
            var json = JsonConvert.SerializeObject(newCheckUpDTO);
            await GetContentAsync(newCheckUpDTO, "https://localhost:7236/api/CheckUp");
            return RedirectToAction("Index", "Home", null);
        }
        private async Task<IActionResult> GetContentAsync(NewCheckUpDTO newCheckup, string url)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }
    }
}
