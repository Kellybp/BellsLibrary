using BellsLibrary.API.Services.Models;

namespace BellsLibrary.UI.Services.Contracts
{
    public interface ILoanService
    {
        Task<IEnumerable<LoanEntity>> GetAllLoansAsync();
        Task<LoanEntity> AddLoanAsync(LoanEntity entity);
        Task UpdateLoanAsync(LoanEntity entity);
        Task DeleteLoanAsync(LoanEntity entity);
    }
}
