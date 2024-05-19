using AutoMapper;
using BellsLibrary.API.Services.Contracts;
using BellsLibrary.API.Services.Models;
using BellsLibrary.Data.Contracts;
using BLM = BellsLibrary.Data.Models;

namespace BellsLibrary.API.Services.Services
{
    public class LoanService : ILoanService
    {
        private readonly IMapper _mapper;
        private readonly ILoanRepository _repository;
        public LoanService(ILoanRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanEntity>> GetAllAsync()
        {
            var loans = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<LoanEntity>>(loans);
        }

        public async Task<LoanEntity?> GetByIdAsync(Guid id)
        {
            var loan = await _repository.GetByIdAsync(id);
            return _mapper.Map<LoanEntity>(loan);
        }


        public async Task<LoanEntity> CreateAsync(LoanEntity entity)
        {
            var newLoan = _mapper.Map<BLM.Loan>(entity);
            await _repository.CreateAsync(newLoan);
            return _mapper.Map<LoanEntity>(newLoan);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<int> UpdateAsync(LoanEntity updatedLoan)
        {
            var loanToUpdate = _mapper.Map<BLM.Loan>(updatedLoan);
            return await _repository.UpdateAsync(loanToUpdate);
        }

        
    }
}
