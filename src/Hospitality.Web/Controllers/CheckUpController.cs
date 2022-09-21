using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Patient;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

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
            var patient = await GetPatient($"https://localhost:7236/api/Patient?pesel={patientDataForStartVisit.PatientPesel}");
            if (patient != null)
            {
                if (patient.IsInsured)
                {
                    TempData["insured"] = "Patient is Insured";
                }
                else
                {
                    TempData["insured"] = "Patient is Not Insured";
                }
                var newCheckUpDTO = new NewCheckUpDTO { PeselOfPatient = patientDataForStartVisit.PatientPesel, IdPatient = patient.HospitalPatientId, IsInsured = patient.IsInsured };
                return View(newCheckUpDTO);
            }
            return RedirectToAction("StartVisit", "StartVisit", patientDataForStartVisit);
        }

        [HttpPost]
        public async Task<IActionResult> CheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            newCheckUpDTO.IdDoctor = 1;
            await SaveNewCheckupAsync(newCheckUpDTO, "https://localhost:7236/api/CheckUp");
            return RedirectToAction("Index", "Home", null);
        }

        private async Task<PatientDoctorViewDTO> GetPatient(string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode || response is null) return null;
            var patientDoctorViewDTO = JsonConvert.DeserializeObject<PatientDoctorViewDTO>(await response.Content.ReadAsStringAsync());
            if (patientDoctorViewDTO is null) return null;

            return patientDoctorViewDTO;
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