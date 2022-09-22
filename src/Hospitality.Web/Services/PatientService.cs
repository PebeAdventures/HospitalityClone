using Hospitality.Common.DTO.Patient;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;

namespace Hospitality.Web.Services
{
    public class PatientService : IPatientService
    {
        private HttpClient _httpClient;
        public PatientService(IHttpClientFactory httpClientFactory, IMapper mapper)
            => _httpClient = httpClientFactory.CreateClient();

        public async Task<int> GetIdOfPatient(string url, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode || response is null) return 0;
            var patientDoctorViewDTO = JsonConvert.DeserializeObject<PatientDoctorViewDTO>(await response.Content.ReadAsStringAsync());
            if (patientDoctorViewDTO is null) return 0;
            return patientDoctorViewDTO.HospitalPatientId;
        }
    }
}
