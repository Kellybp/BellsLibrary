using BellsLibrary.API.Services.Models;

namespace BellsLibrary.UI.Services.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BookEntity>> GetAllBooksAsync();
        Task<BookEntity> AddBookAsync(BookEntity entity);
        Task UpdateBookAsync(BookEntity entity);
        Task DeleteBookAsync(BookEntity entity);
    }
}
