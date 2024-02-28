using AutoMapper;
using AutoMapper.Execution;
using Library.Entities;
using Solid.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member = Library.Entities.Member;//רשם שיש כפילות?!?!?!?

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
