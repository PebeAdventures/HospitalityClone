﻿using Hospitality.Common.DTO.CheckUp;
using Hospitality.Common.DTO.Examination;
using Hospitality.Common.DTO.Temperature;
using Hospitality.Web.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http.Headers;
using System.Text;
using System.Xml.Linq;

namespace Hospitality.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Doctor")]
    public class TemperatureController : Controller
    {
        private HttpClient _httpClient;
        private List<PatientTemperaturesViewDTO> patientTemperaturesViewDTO;
        private ITemperatureService _temperatureService;
        private readonly IConfiguration _configuration;

        public TemperatureController(IHttpClientFactory httpClientFactory, ITemperatureService temperatureService, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            patientTemperaturesViewDTO = new List<PatientTemperaturesViewDTO>();
            _temperatureService = temperatureService;
            _configuration = configuration;
        }


        [HttpPost]
        public async Task<IActionResult> TemperatureControl(string patientPesel)
        {

            var patientTemperatures = await _temperatureService.GetPatientTemperatures(patientPesel, HttpContext.Session.GetString("token"));
            if (patientTemperatures != null)
            {
                return View(patientTemperatures);
            }
            patientTemperatures = new List<PatientTemperaturesViewDTO>() { new PatientTemperaturesViewDTO() { PatientId = patientPesel, Temperature = 0, MeasurementDate = DateTime.Now } };
            return View(patientTemperatures);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewTemperatureToPatient(string actualPatientTemperature, string patientPesel)
        {


            decimal decimalValue;
            if (!Decimal.TryParse(actualPatientTemperature, out decimalValue))
            {

                return Content(@"<script>alert(""Wrong property"");window.close();</script>", "text/html");

            }
            string patientTemperatureWithDots = actualPatientTemperature.Replace(",", ".");
            NewPatientTemperatureDTO newPatientTemperatureDTO = new NewPatientTemperatureDTO()
            {
                PatientId = patientPesel,
                Temperature = Decimal.Parse(patientTemperatureWithDots)
            };
            await SaveNewTemperature(newPatientTemperatureDTO, _configuration["Paths:AddPatientTemperature"]);
            return Content(@"<script>window.close();</script>", "text/html");

        }





        private async Task SaveNewTemperature(NewPatientTemperatureDTO newPatientTemperatureDTO, string url)
        {

            var json = JsonConvert.SerializeObject(newPatientTemperatureDTO);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));
            await _httpClient.PostAsync(url, content);

        }
    }
}
