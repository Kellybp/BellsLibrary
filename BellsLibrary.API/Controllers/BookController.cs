using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using BellsLibrary.API.Models;
using BellsLibrary.API.Services.Contracts;
using BellsLibrary.API.Services.Models;

namespace BellsLibrary.API.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet(Name = nameof(GetBooks))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<BookEntity>> GetBooks()
        {
            var books = await _service.GetAllAsync();
            return books;
        }

        [HttpGet("{id:guid}", Name = "BookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<NotFound, Ok<BookEntity>>> GetBookById(Guid id)
        {
            var book = await _service.GetByIdAsync(id);

            return book == null ? TypedResults.NotFound() :
                                   TypedResults.Ok(book);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] BookEntity newBook)
        {
            var createdBook = await _service.CreateAsync(newBook);
            return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
        }


        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] BookEntity book)
        {
            book.Id = id;
            var result = await _service.UpdateAsync(book);
            return result == 1 ? Ok() : NotFound();
        }

        // DELETE api/book/5
        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var result = await _service.DeleteAsync(id);
                return result == 1 ? Ok() : NotFound();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
