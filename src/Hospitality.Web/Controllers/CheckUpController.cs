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

        private HttpClient _httpClient;
        public CheckUpController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();
       


        public IActionResult CheckUp(PatientDataForStartVisit patientDataForStartVisit)
        {
            string patientID = "";
            if (patientDataForStartVisit.PatientPesel != null)
            {
               // patientID = Int32.Parse(patientDataForStartVisit.PatientPesel);
            }
            TempData["patientId"] = patientDataForStartVisit.PatientPesel;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            //newCheckUpDTO.IdPatient = (int)TempData["patientId"];
            newCheckUpDTO.IdPatient = 123;
            
            var json = JsonConvert.SerializeObject(newCheckUpDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await GetContentAsync(newCheckUpDTO, "https://localhost:7236/api/CheckUp");

            return RedirectToAction("Index", "Home", null);
        }
        private async Task<IActionResult> GetContentAsync(NewCheckUpDTO newCheckup, string url)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var token = HttpContext.Session.GetString("token");
            var kupa = new AuthenticationHeaderValue("Bearer", token);
            _httpClient.DefaultRequestHeaders.Authorization = kupa;
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }
    }
}
