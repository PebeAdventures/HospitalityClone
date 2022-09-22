using AutoMapper;
using Hospitality.Common.DTO.Examination;
using Hospitality.Examination.Application.Functions.Examinations.Queries;
using Hospitality.Examination.Domain.Entities;
using Hospitality.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Policy;

namespace Hospitality.Web.Services
{
    public class ExaminationService : IExaminationService
    {
        private HttpClient _httpClient;
        public ExaminationService(IHttpClientFactory httpClientFactory, IMapper mapper)
            => _httpClient = httpClientFactory.CreateClient();

        public async Task<List<ExaminationTypeDto>> GetAvailableExaminations(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync("https://localhost:7236/api/Examination/TypesOfExaminations");
            if (!response.IsSuccessStatusCode || response is null)
                throw new Exception("Null response exception");
            var availableExaminations = JsonConvert.DeserializeObject<List<ExaminationTypeDto>>(await response.Content.ReadAsStringAsync());
            if (availableExaminations is null)
                throw new Exception("Null response exception");
            return availableExaminations;
        }

        public async Task<List<ExaminationInfoDto>> GetPatientExaminations(GetPatientExaminationsQuery getPatientExaminationsQuery, string token)
        {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            int patientId = getPatientExaminationsQuery.PatientId;
            var response = await _httpClient.GetAsync($"https://localhost:7236/api/Examination/PatientExaminationsResults?id={patientId}");
            if (!response.IsSuccessStatusCode || response is null) return null;
            List<ExaminationInfoDto> examinationInfo = JsonConvert.DeserializeObject<List<ExaminationInfoDto>>(await response.Content.ReadAsStringAsync());
            if (examinationInfo is null) return null;
            return examinationInfo;
        }

    }
}
