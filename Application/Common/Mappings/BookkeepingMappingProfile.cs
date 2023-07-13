using Application.Common.Models;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class BookkeepingMappingProfile : Profile
    {
        public BookkeepingMappingProfile()
        {
            CreateMap<Bookkeeping, BookkeepingGetDto>().ReverseMap();
        }
    }
}
