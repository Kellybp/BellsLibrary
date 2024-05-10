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
    public class LoanController : ControllerBase
    {
        private readonly LibraryContext _context;

        public LoanController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Loan>>> GetAllLoans() {

            var loans = await _context.Loans.ToListAsync();

            return Ok(loans);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Loan>> GetLoanById(int id)
        {

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
                return BadRequest("Loan not found");

            return Ok(loan);
        }

        [HttpPost]
        public async Task<ActionResult<Loan>> AddLoan(Loan loan)
            //Create Data Transfer Object (DTO)
        {
            
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return Ok(await _context.Loans.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Loan>> EditLoan(Loan updatedLoan)
        //Create Data Transfer Object (DTO)
        {
            var loan = await _context.Loans.FindAsync(updatedLoan.ID);
            if (loan == null)
                return BadRequest("Loan not found");

            loan.LoanDate = updatedLoan.LoanDate;
            loan.BookId = updatedLoan.BookId;
            loan.AccountId = updatedLoan.AccountId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Loans.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Loan>> DeleteLoan(int id)
        {

            var loan = await _context.Loans.FindAsync(id);
            if (loan == null)
                return BadRequest("Loan not found");

            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return Ok(await _context.Loans.ToListAsync());
        }
    }
}
