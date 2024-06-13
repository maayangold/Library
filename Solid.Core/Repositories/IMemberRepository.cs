﻿using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IMemberRepository
    {
        public Task<IEnumerable<Member>> GetMembersAsync();

        public Task<Member> GetByIdAsync(int id);

        public Task<Member> AddAsync(Member m);
        public Task<Borrow> BorrowBooksAsync(int memberId, List<int> bookIds);
        
        public Task<Member> PutAsync(int id, Member value);

        public Task<Member> PutStatusAsync(int id);

        public Task<Member> DeleteAsync(int id);
    }
}
