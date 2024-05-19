using AutoMapper;
using Library.Entities;
using Solid.Core.DTOs;

namespace Solid.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Borrow, BorrowDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();

        }
    }
}
