using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using BellsLibrary.API.Models;
using BellsLibrary.API.Services.Contracts;
using BellsLibrary.API.Services.Models;

namespace BellsLibrary.API.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;

        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [HttpGet(Name = nameof(GetLoans))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<LoanEntity>> GetLoans()
        {
            var loans = await _service.GetAllAsync();
            return loans;
        }

        [HttpGet("{id:guid}", Name = "LoanById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<NotFound, Ok<LoanEntity>>> GetLoanById(Guid id)
        {
            var loan = await _service.GetByIdAsync(id);

            return loan == null ? TypedResults.NotFound() :
                                   TypedResults.Ok(loan);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] LoanEntity newLoan)
        {
            var createdLoan = await _service.CreateAsync(newLoan);
            return CreatedAtAction(nameof(GetLoanById), new { id = createdLoan.Id }, createdLoan);
        }


        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(Guid id, [FromBody] LoanEntity loan)
        {
            loan.Id = id;
            var result = await _service.UpdateAsync(loan);
            return result == 1 ? Ok() : NotFound();
        }

        // DELETE api/loan/5
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
