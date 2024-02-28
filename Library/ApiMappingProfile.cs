using AutoMapper;
using Library.Entities;
using Library.Models;

namespace Library
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<MemberPostModel, Member>().ReverseMap();
            CreateMap<BorrowPostModel,Borrow >().ReverseMap();
            CreateMap<BookPostModel, Book>().ReverseMap();

        }
    }
}
