using Insurance.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Web.Client
{
    public class AppClient: IAppClient
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContext;
        private readonly string _token;
        private readonly string _username;

        public AppClient(HttpClient client, IHttpContextAccessor httpContext)
        {
            _client = client;
            _httpContext = httpContext;
            _token = _httpContext.HttpContext.Session.GetString("token");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            _username = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }

        public async Task AddInsuranceAsync(InsuranceNewEditModel insurance)
        {
            insurance.UserCreate = _username;
            var content = JsonConvert.SerializeObject(insurance);

            using var response = await _client.PostAsync($"/api/insurance?username={_username}",
                new StringContent(content, Encoding.UTF8, "application/json"));
        }

        public async Task DeleteInsuranceAsync(int id)
        {
            using var response = await _client.DeleteAsync($"/api/insurance/{id}?username={_username}");
        }

        public async Task<List<CoverTypeModel>> GetAllCoverTypesAsync()
        {
            using var response = await _client.GetAsync("/api/covertype");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var coverTypes = JsonConvert.DeserializeObject<List<CoverTypeModel>>(apiResponse);
            return coverTypes;
        }

        public async Task<List<LocationModel>> GetAllLocationsAsync()
        {
            using var response = await _client.GetAsync("/api/location");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var locations = JsonConvert.DeserializeObject<List<LocationModel>>(apiResponse);
            return locations;
        }

        public async Task<List<RiskTypeModel>> GetAllRiskTypesAsync()
        {
            using var response = await _client.GetAsync("/api/risktype");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var riskTypes = JsonConvert.DeserializeObject<List<RiskTypeModel>>(apiResponse);
            return riskTypes;
        }

        public async Task<InsuranceModel> GetInsuranceByIdAsync(int id)
        {
            using var response = await _client.GetAsync($"/api/insurance/{id}?username={_username}");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var insurance = JsonConvert.DeserializeObject<InsuranceModel>(apiResponse);
            return insurance;
        }

        public async Task<List<InsuranceModel>> GetInsurancesAsync()
        {
            using var response = await _client.GetAsync("/api/insurance");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var insurances = JsonConvert.DeserializeObject<List<InsuranceModel>>(apiResponse);
            return insurances;
        }

        public async Task<List<string>> GetRolesByUserIdAsync(int id)
        {
            using var response = await _client.GetAsync($"/api/auth/{id}/roles");
            string apiResponse = await response.Content.ReadAsStringAsync();

            var roles = JsonConvert.DeserializeObject<List<string>>(apiResponse);
            return roles;
        }

        public async Task<string> LoginAsync(LoginModel login)
        {
            var content = JsonConvert.SerializeObject(login);

            using var response = await _client.PostAsync("/api/auth/login",
                new StringContent(content, Encoding.UTF8, "application/json"));

           return await response.Content.ReadAsStringAsync();
        }

        public async Task UpdateInsuranceAsync(InsuranceModel insurance)
        {
            var content = JsonConvert.SerializeObject(insurance);

            using var response = await _client.PutAsync($"/api/insurance?username={_username}",
                new StringContent(content, Encoding.UTF8, "application/json"));
        }
    }
}
