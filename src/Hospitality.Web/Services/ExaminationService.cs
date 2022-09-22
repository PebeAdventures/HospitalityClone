using Hospitality.Common.DTO.Examination;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using AutoMapper;
using Hospitality.Web.Services.Interfaces;

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
    }
}
