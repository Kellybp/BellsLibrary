using AutoMapper;
using BellsLibrary.Data.Models;
using BellsLibrary.API.Services.Models;

namespace BellsLibrary.API.Services.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile() {
            CreateMap<Book, BookEntity>()
                    .ReverseMap();
        }
    }
}
