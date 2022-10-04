using Hospitality.Common.DTO.Examination;
using Hospitality.Common.DTO.Temperature;
using Hospitality.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Hospitality.Web.Services
{
    public class TemperatureService : ITemperatureService
    {


        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TemperatureService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();

        }

        public async Task<List<PatientTemperaturesViewDTO>> GetPatientTemperatures(string patientId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(_configuration["Paths:PatientTemperaturesList"] + patientId);
            if (!response.IsSuccessStatusCode || response is null) return null;
            List<PatientTemperaturesViewDTO> temperatureInfo = JsonConvert.DeserializeObject<List<PatientTemperaturesViewDTO>>(await response.Content.ReadAsStringAsync());
            if (temperatureInfo is null) return null;
            return temperatureInfo;
        }

    }
}
