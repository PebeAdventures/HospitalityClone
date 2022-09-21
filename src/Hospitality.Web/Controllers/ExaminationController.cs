﻿using Hospitality.Common.DTO.Examination;
using Hospitality.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;

namespace Hospitality.Web.Controllers
{
    public class ExaminationController : Controller
    {
        private HttpClient _httpClient;
        private IMapper _mapper;
        private IExaminationService _examinationService;
        private IPatientService _patientService;
        public ExaminationController(IHttpClientFactory httpClientFactory, IMapper mapper, IExaminationService examinationService, IPatientService patientService)
        {
            _httpClient = httpClientFactory.CreateClient();
            _mapper = mapper;
            _examinationService = examinationService;
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<IActionResult> OrderAnExamination(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
        {
            if (!string.IsNullOrEmpty(patientDataCheckUpViewModel.ChosenExamination))
                await AssignIdOfChosenExamination(patientDataCheckUpViewModel);
            if (!string.IsNullOrEmpty(patientDataCheckUpViewModel.PatientPesel))
                await AssignIdOfPatient(patientDataCheckUpViewModel);
            await SendOrder(patientDataCheckUpViewModel, "https://localhost:7236/api/Examination");
            return RedirectToAction("CheckUp", "CheckUp", patientDataCheckUpViewModel);
        }

        private async Task AssignIdOfPatient(PatientDataCheckUpViewModel patientDataCheckUpViewModel)
            => patientDataCheckUpViewModel.PatientId = await _patientService.GetIdOfPatient($"https://localhost:7236/api/Patient?pesel={patientDataCheckUpViewModel.PatientPesel}", HttpContext.Session.GetString("token"));
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
