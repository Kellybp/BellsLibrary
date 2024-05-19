using AutoMapper;
using BellsLibrary.Data.Models;
using BellsLibrary.API.Services.Models;

namespace BellsLibrary.API.Services.Mappers
{
    public class LoanProfile : Profile
    {
        public LoanProfile() {
            CreateMap<Loan, LoanEntity>()
                    .ReverseMap();
        }
    }
}
