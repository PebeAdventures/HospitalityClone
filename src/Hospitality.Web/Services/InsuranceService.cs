using Hospitality.Common.DTO.NewFolder;
using Hospitality.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Hospitality.Web.Services
{
    public class InsuranceService : IInsuranceService
    {
        private HttpClient _httpClient;
        public InsuranceService(IHttpClientFactory httpClientFactory)
            => _httpClient = httpClientFactory.CreateClient();
        public async Task<bool> CheckHealthInsurance(int idOfPerson, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync($"https://localhost:7236/api/Insurance?idOfPerson={idOfPerson}");
            return JsonConvert.DeserializeObject<InsuredDTO>(await response.Content.ReadAsStringAsync()).IsInsured;
        }
    }
}
