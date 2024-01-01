using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Entities;

namespace Solid.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;
        public List<Member> GetMembers()
        {
            return _context.Members;
        }
    
}
}
