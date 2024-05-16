using BellsLibrary.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using BLM = BellsLibrary.Data.Models;

namespace BellsLibrary.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BellsLibraryContext _context;
        public BookRepository(BellsLibraryContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<BLM.Book>> GetAllAsync()
        {
            var result =  await _context.Books
                                .OrderByDescending(b => b.Title)
                                .ToListAsync();
            return result; 
        }

        public async Task<BLM.Book?> GetByIdAsync(Guid id)
        {
            var result =  await _context.Books.FirstOrDefaultAsync(b => b.Id == id);

            return result;

        }


        public async Task<BLM.Book> CreateAsync(BLM.Book newBook)
        {
            newBook.Id = Guid.NewGuid();

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return -1;

            _context.Books.Remove(book);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateAsync(BLM.Book updatedBook)
        {
            var oldBook = await _context.Books.FindAsync(updatedBook.Id);

            if (oldBook == null)
            {
                return -1;
            }
            oldBook.Title = updatedBook.Title;
            oldBook.Description = updatedBook.Description;
            oldBook.Author = updatedBook.Author;
            oldBook.ISBN = updatedBook.ISBN;
            oldBook.Publisher = updatedBook.Publisher;
            oldBook.PublicationDate = updatedBook.PublicationDate;
            oldBook.Category = updatedBook.Category;
            oldBook.CoverImage = updatedBook.CoverImage;
            oldBook.PgCount = updatedBook.PgCount;

            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
