using Hospitality.Common.DTO.CheckUp;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Hospitality.Common.DTO.Patient;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]

    public class CheckUpController : Controller
    {
        private HttpClient _httpClient;
        public CheckUpController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();

        [HttpGet]
        public async Task<IActionResult> CheckUp(PatientDataForStartVisit patientDataForStartVisit)
        {
            var idOfPatient = await GetIdOfPatient($"https://localhost:7236/api/Patient?pesel={patientDataForStartVisit.PatientPesel}");
            if (idOfPatient != 0)
            {
                var newCheckUpDTO = new NewCheckUpDTO {PeselOfPatient = patientDataForStartVisit.PatientPesel, IdPatient = idOfPatient};
                return View(newCheckUpDTO);
            }
            return RedirectToAction("StartVisit", "StartVisit", patientDataForStartVisit);
        }

        [HttpPost]
        public async Task<IActionResult> CheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            newCheckUpDTO.IdDoctor = 1; // Napisać coś co na podstawie jwt bedzie zapisywać w sesji id doktora i w tym miejscu będzie można pobierać id doktora z sesji
            await SaveNewCheckupAsync(newCheckUpDTO, "https://localhost:7236/api/CheckUp");
            return RedirectToAction("Index", "Home", null);
        }
        private async Task<int> GetIdOfPatient(string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode || response is null) return 0;
            var patientDoctorViewDTO = JsonConvert.DeserializeObject<PatientDoctorViewDTO>(await response.Content.ReadAsStringAsync()); 
            if (patientDoctorViewDTO is null) return 0;
            return patientDoctorViewDTO.HospitalPatientId;
        }
        private async Task<IActionResult> SaveNewCheckupAsync(NewCheckUpDTO newCheckup, string url)
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