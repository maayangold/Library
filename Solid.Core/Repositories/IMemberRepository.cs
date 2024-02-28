using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Repositories
{
    public interface IMemberRepository
    {
        List<Member> GetMembers(); 

        public Member GetById(int id);

        public Member Add(Member m);
        // public Book Post(Book b);

        public Member Put(int id, Member value);

        public Member PutStatus(int id);
        public Member Delete(int id);
    }
}
