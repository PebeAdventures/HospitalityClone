using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Domain.Entities;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class ResultController : Controller
    {

        private HttpClient _httpClient;
        private List<ExaminationInfoDto> examinationInfoDto;
        public ResultController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            examinationInfoDto = new List<ExaminationInfoDto>();
        }

        [HttpPost]
        public async Task<IActionResult> Result(string patientId)
        {

            var patientExaminations = await CurrentPatientExaminations($"https://localhost:7236/api/Examination/PatientExaminationsResults?id={patientId}");

            if (patientExaminations != null)
            {

                foreach (var examination in patientExaminations)
                {
                    examinationInfoDto.Add(new ExaminationInfoDto()
                    {
                        Id = examination.Id,
                        Description = examination.Description,
                        TypeName = "test",
                        Status = "status"
                    });
                }
                return View(examinationInfoDto);
            }
            examinationInfoDto = new List<ExaminationInfoDto>() { new ExaminationInfoDto(){TypeName="no examinations",
                Description="This patient dont have any examinations", Id=0 } };
            return View(examinationInfoDto);

        }

        private async Task<List<ExaminationInfo>> CurrentPatientExaminations(string url)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode || response is null) return null;
            List<ExaminationInfo> examinationInfo = JsonConvert.DeserializeObject<List<ExaminationInfo>>(await response.Content.ReadAsStringAsync());
            if (examinationInfo is null) return null;
            return examinationInfo;
        }

    }
}
