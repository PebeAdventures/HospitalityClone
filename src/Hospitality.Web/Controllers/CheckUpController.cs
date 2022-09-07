﻿using Hospitality.Common.DTO.CheckUp;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Hospitality.Web.Controllers
{
    public class CheckUpController : Controller
    {

        private HttpClient _httpClient;
        public CheckUpController(IHttpClientFactory httpClientFactory)
             => _httpClient = httpClientFactory.CreateClient();
        private async Task<IActionResult> GetContentAsync(object newCheckup, string url)
        {
            var json = JsonConvert.SerializeObject(newCheckup);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode || response is null) return StatusCode(404);
            return StatusCode(201);
        }


        public IActionResult CheckUp(PatientDataForStartVisit patientDataForStartVisit)
        {
            int patientID = Int32.Parse(patientDataForStartVisit.PatientId = "123123123");

            TempData["Message"] = patientID;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CheckUp(NewCheckUpDTO newCheckUpDTO)
        {

            newCheckUpDTO.IdPatient = (int)TempData["Message"];
            if (!ModelState.IsValid)
            {
                return View(newCheckUpDTO);
            }
            //  await GetContentAsync(newCheckUpDTO, "ADRES GATEWAY CHECKUP");

            return RedirectToAction("CheckUp");
        }
    }
}