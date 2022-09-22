using Hospitality.Common.DTO.Examination;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;
using System.Security.Principal;

namespace Hospitality.Web.Controllers
{
    public class ExaminationController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IExaminationService _examinationService;
        private IPatientService _patientService;
        private readonly IConfiguration _configuration;

        public ExaminationController(IHttpClientFactory httpClientFactory, IMapper mapper, IExaminationService examinationService, IPatientService patientService, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _examinationService = examinationService;
            _patientService = patientService;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Examination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            patientDataCheckUpViewModel.AvailableExaminations = (await _examinationService.GetAvailableExaminations(HttpContext.Session.GetString("token"))).Select(x => x.Name).ToList();
            return View(patientDataCheckUpViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> OrderAnExamination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            if (!string.IsNullOrEmpty(patientDataCheckUpViewModel.ChosenExamination))
                await AssignIdOfChosenExamination(patientDataCheckUpViewModel);
            if (!string.IsNullOrEmpty(patientDataCheckUpViewModel.PatientPesel))
                await AssignIdOfPatient(patientDataCheckUpViewModel);
            await SendOrder(patientDataCheckUpViewModel, _configuration["Paths:CreateExamination"]);
            return Content(@"<script>window.close();</script>", "text/html");
        }

        private async Task AssignIdOfPatient(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
            => patientDataCheckUpViewModel.PatientId = await _patientService.GetIdOfPatient(_configuration["Paths:GetPatientByPesel"] + patientDataCheckUpViewModel.PatientPesel, HttpContext.Session.GetString("token"));
        private async Task AssignIdOfChosenExamination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
            => patientDataCheckUpViewModel.ChosenExaminationId = (await _examinationService.GetAvailableExaminations(HttpContext.Session.GetString("token"))).Where(ae => ae.Name == patientDataCheckUpViewModel.ChosenExamination).FirstOrDefault().Id;
        private async Task SendOrder(PatientDataCheckUpViewModel patientDataCheckUpViewModel, string url)
        {
            //var examinationDto = _mapper.Map<CreateExaminationDto>(patientDataCheckUpViewModel);
            var examinationDto = new CreateExaminationDto() { ExaminationTypeId = patientDataCheckUpViewModel.ChosenExaminationId, PatientId = patientDataCheckUpViewModel.PatientId };
            var json = JsonConvert.SerializeObject(examinationDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, content);
        }
        
    }
}
