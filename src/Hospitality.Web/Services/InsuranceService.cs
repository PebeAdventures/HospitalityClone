using Hospitality.Common.DTO.NewFolder;
using Hospitality.Web.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Hospitality.Web.Services
{
    public class InsuranceService : IInsuranceService
    {
        private HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public InsuranceService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        public async Task<bool> CheckHealthInsurance(int idOfPerson, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return JsonConvert.DeserializeObject<InsuredDTO>(await (await _httpClient.GetAsync(
                _configuration["Paths:CheckInsurance"] + idOfPerson)).Content.ReadAsStringAsync()).IsInsured;
        }
    }
}