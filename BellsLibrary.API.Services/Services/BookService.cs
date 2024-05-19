using AutoMapper;
using BellsLibrary.API.Services.Contracts;
using BellsLibrary.API.Services.Models;
using BellsLibrary.Data.Contracts;
using BLM = BellsLibrary.Data.Models;

namespace BellsLibrary.API.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repository;
        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookEntity>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookEntity>>(books);
        }

        public async Task<BookEntity?> GetByIdAsync(Guid id)
        {
            var book = await _repository.GetByIdAsync(id);
            return _mapper.Map<BookEntity>(book);
        }


        public async Task<BookEntity> CreateAsync(BookEntity entity)
        {
            var newBook = _mapper.Map<BLM.Book>(entity);
            await _repository.CreateAsync(newBook);
            return _mapper.Map<BookEntity>(newBook);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<int> UpdateAsync(BookEntity updatedBook)
        {
            var bookToUpdate = _mapper.Map<BLM.Book>(updatedBook);
            return await _repository.UpdateAsync(bookToUpdate);
        }

        
    }
}
