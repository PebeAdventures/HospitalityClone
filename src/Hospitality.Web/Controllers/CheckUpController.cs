using Hospitality.Common.DTO.CheckUp;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Hospitality.Common.DTO.Patient;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]

    public class CheckUpController : Controller
    {
        private string pesel;
        private HttpClient _httpClient;
        public CheckUpController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();
        
        [HttpGet]
        public IActionResult CheckUp(string peselInString)
        {
            //TempData["pesel"] = peselInString;
            return View(new NewCheckUpDTO() { PeselOfPatient = peselInString});
        }

        [HttpPost]
        public async Task<IActionResult> CheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            //var idOfPatient = await GetIdOfPatient(newCheckUpDTO.PeselOfPatient);
            //if (idOfPatient == 0)
            //{
            //    return RedirectToAction("StartVisit", "StartVisit");
            //}
            //newCheckUpDTO.IdPatient = idOfPatient;
            newCheckUpDTO.IdPatient = 1;
            if (!ModelState.IsValid)
            {
                return View(newCheckUpDTO);
            }
            var json = JsonConvert.SerializeObject(newCheckUpDTO);
            await GetContentAsync(newCheckUpDTO, "https://localhost:7236/api/CheckUp");
            return RedirectToAction("Index", "Home", null);
        }
        private async Task<int> GetIdOfPatient(string pesel)
        {
            var json = JsonConvert.SerializeObject(pesel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.PostAsync($"https://localhost:7236/api/Patient?pesel={pesel}", content);
            var dupa = System.Text.Json.JsonSerializer.Deserialize<PatientDoctorViewDTO>(await response.Content.ReadAsStringAsync());
            if (dupa is null) return 0;
            return dupa.HospitalPatientId;
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
