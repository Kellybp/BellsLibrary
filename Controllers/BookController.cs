using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using BellsLibrary.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using BellsLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace BellsLibrary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks() {

            var books = await _context.Books.ToListAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found");

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Book>> EditBook(Book updatedBook)
        {
            var book = await _context.Books.FindAsync(updatedBook.ID);
            if (book == null)
                return BadRequest("Book not found");

            book.Title = updatedBook.Title;
            book.Description = updatedBook.Description;
            book.Author = updatedBook.Author;
            book.ISBN = updatedBook.ISBN;
            book.Publisher = updatedBook.Publisher;
            book.PublicationDate = updatedBook.PublicationDate;
            book.Category = updatedBook.Category;
            book.CoverImage = updatedBook.CoverImage;
            book.PgCount = updatedBook.PgCount;

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {

            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return BadRequest("Book not found");

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }
    }
}
