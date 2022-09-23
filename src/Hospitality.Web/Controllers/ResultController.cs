using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Functions.Examinations.Queries;
using Hospitality.Examination.Domain.Entities;
using Hospitality.Web.Models;
using Hospitality.Web.Services.Interfaces;
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
        private IExaminationService _examinationService;
        public ResultController(IHttpClientFactory httpClientFactory, IExaminationService examinationService)
        {
            _httpClient = httpClientFactory.CreateClient();
            examinationInfoDto = new List<ExaminationInfoDto>();
            _examinationService = examinationService;
        }

        [HttpPost]
        public async Task<IActionResult> Result(string patientId)
        {
            GetPatientExaminationsQuery getPatientExaminationsQuery = new GetPatientExaminationsQuery() { PatientId = int.Parse(patientId) };
            var patientExaminations = await _examinationService.GetPatientExaminations(getPatientExaminationsQuery, HttpContext.Session.GetString("token"));
            if (patientExaminations != null)
            {

                //foreach (var examination in patientExaminations)
                //{
                //    examinationInfoDto.Add(new ExaminationInfoDto()
                //    {
                //        Id = examination.Id,
                //        Description = examination.Description,
                //        // TypeName = examination.Type.Name,
                //        Status = examination.Status.ToString()
                //    });
                //}
                return View(patientExaminations);
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
