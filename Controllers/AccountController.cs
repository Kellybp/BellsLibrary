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
    public class AccountController : ControllerBase
    {
        private readonly LibraryContext _context;

        public AccountController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllAccounts() {

            var accounts = await _context.Accounts.ToListAsync();

            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {

            var account = await _context.Books.FindAsync(id);
            if (account == null)
                return BadRequest("Account not found");

            return Ok(account);
        }

        [HttpPost]
        public async Task<ActionResult<Account>> AddAccount(Account account)
            //Create Data Transfer Object (DTO)
        {
            
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<Account>> EditAccount(Account updatedAccount)
        //Create Data Transfer Object (DTO)
        {
            var account = await _context.Accounts.FindAsync(updatedAccount.ID);
            if (account == null)
                return BadRequest("Book not found");

            account.AccountType = updatedAccount.AccountType;
            account.UserName = updatedAccount.UserName;
            account.FirstName = updatedAccount.FirstName;
            account.LastName = updatedAccount.LastName;
            account.Password = updatedAccount.Password;

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Account>> DeleteAccount(int id)
        {

            var account = await _context.Books.FindAsync(id);
            if (account == null)
                return BadRequest("Book not found");

            _context.Books.Remove(account);
            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
        }
    }
}
