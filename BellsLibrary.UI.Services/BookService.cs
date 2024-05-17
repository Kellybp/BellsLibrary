using BellsLibrary.UI.Services.Contracts;
using BellsLibrary.API.Services.Models;
using System.Net.Http.Json;

namespace BellsLibrary.UI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private const string _baseUri = "/api/book";

        public BookService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AdminAPI");
        }

        public async Task<BookEntity> AddBookAsync(BookEntity entity)
        {
            var response = await _httpClient.PostAsJsonAsync(_baseUri, entity);
            response.EnsureSuccessStatusCode();
            return (await response.Content.ReadFromJsonAsync<BookEntity>())!;
        }

        public async Task DeleteBookAsync(BookEntity entity)
        {
            var deleteUri = $"{_baseUri}/{entity.Id}";
            var response = await _httpClient.DeleteAsync(deleteUri);
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<BookEntity>> GetAllBooksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<BookEntity>>(_baseUri) ?? Array.Empty<BookEntity>();
        }

        public async Task UpdateBookAsync(BookEntity entity)
        {
            var updateUri = $"{_baseUri}/{entity.Id}";
            var response = await _httpClient.PutAsJsonAsync(updateUri, entity);
            response.EnsureSuccessStatusCode();
        }
    }
}
