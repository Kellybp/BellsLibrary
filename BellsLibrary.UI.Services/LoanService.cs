using BellsLibrary.API.Services.Models;
using BellsLibrary.UI.Services.Contracts;
using System.Net.Http.Json;

namespace BellsLibrary.UI.Services
{
    public class LoanService : ILoanService
    {
        private readonly HttpClient _httpClient;
        private const string _baseUri = "https://localhost:7055/api/loan";//Temp Fix - Add method to take in hard coded URI

        public LoanService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("Api");
        }

        public async Task<LoanEntity> AddLoanAsync(LoanEntity entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUri, entity);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<LoanEntity>())!;
        }

        public async Task DeleteLoanAsync(LoanEntity entity)
        {
            var deleteUri = $"{_baseUri}/{entity.Id}";
            var response = await _httpClient.DeleteAsync(deleteUri);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<LoanEntity>> GetAllLoansAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<LoanEntity>>(_baseUri) ?? Array.Empty<LoanEntity>();
        }

        public async Task UpdateLoanAsync(LoanEntity entity)
        {
            var updateUri = $"{_baseUri}/{entity.Id}";
            var response = await _httpClient.PutAsJsonAsync(updateUri, entity);
            response.EnsureSuccessStatusCode();
        }
    }
}
