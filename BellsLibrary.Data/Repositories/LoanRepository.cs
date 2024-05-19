using BellsLibrary.Data.Contracts;
using Microsoft.EntityFrameworkCore;
using BLM = BellsLibrary.Data.Models;

namespace BellsLibrary.Data.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly BellsLibraryContext _context;
        public LoanRepository(BellsLibraryContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<BLM.Loan>> GetAllAsync()
        {
            var result =  await _context.Loans.ToListAsync();
            return result; 
        }

        public async Task<BLM.Loan?> GetByIdAsync(Guid id)
        {
            var result =  await _context.Loans.FirstOrDefaultAsync(b => b.Id == id);

            return result;

        }


        public async Task<BLM.Loan> CreateAsync(BLM.Loan newBook)
        {
            newBook.Id = Guid.NewGuid();

            await _context.Loans.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            var book = await _context.Loans.FindAsync(id);
            if (book == null)
                return -1;

            _context.Loans.Remove(book);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateAsync(BLM.Loan updatedLoan)
        {
            var oldLoan = await _context.Loans.FindAsync(updatedLoan.Id);

            if (oldLoan == null)
            {
                return -1;
            }
            oldLoan.LoanDate = updatedLoan.LoanDate;
            oldLoan.BookId = updatedLoan.BookId;
            //oldLoan.AccountId = updatedLoan.AccountId;

            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
