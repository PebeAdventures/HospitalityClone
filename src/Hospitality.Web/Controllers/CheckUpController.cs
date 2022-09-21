using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Examination;
using Hospitality.Common.DTO.Patient;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var idOfPatient = await GetIdOfPatient($"https://localhost:7236/api/Patient?pesel={patientDataForStartVisit.PatientPesel}");
            if (idOfPatient != 0)
            {
                ViewBag.Examinations = new SelectList(GetExamination(),

                /*  nameof(ExaminationInfoDto.Description),
                  nameof(ExaminationInfoDto.Id),
                  nameof(ExaminationInfoDto.Status),
                  nameof(ExaminationInfoDto.TypeName))*/
                "Description", "Id", "Status", "TypeName")
               ;
                var newCheckUpDTO = new NewCheckUpDTO
                {
                    PeselOfPatient = patientDataForStartVisit.PatientPesel,
                    IdPatient = idOfPatient,
                    Examinations = new SelectList(GetExamination(),

                   //   /*  nameof(ExaminationInfoDto.Description),
                   //     nameof(ExaminationInfoDto.Id),
                   //     nameof(ExaminationInfoDto.Status),
                   //     nameof(ExaminationInfoDto.TypeName))*/
                   "Description", "Id", "Status", "TypeName")
                };
                return View(newCheckUpDTO);
            }
            return RedirectToAction("StartVisit", "StartVisit", patientDataForStartVisit);
        }
        public IEnumerable<ExaminationInfoDto> GetExamination()
        {
            return new List<ExaminationInfoDto>
    {
                    new ExaminationInfoDto { Description = "test 1", Id = 1, Status = "null", TypeName = "test" },
                    new ExaminationInfoDto { Description = "test 2", Id = 2, Status = "null2", TypeName = "test2" }
    };
        }





        [HttpPost]
        public async Task<IActionResult> CheckUp(NewCheckUpDTO newCheckUpDTO)
        {
            newCheckUpDTO.IdDoctor = 1;
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