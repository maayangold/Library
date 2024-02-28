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
            return _context.Members.ToList();
        }
        public Member GetById(int id)
        {
            return _context.Members.Find(id);
        }

        public Member Add(Member m)
        {
            _context.Members.Add(m);
            _context.SaveChanges();
            return m;
        }


        public Member Put(int id, Member value)
        {
            Member m = _context.Members.Find(id);
            if (m != null)
            {
                m.Name = value.Name;
                m.Tel = value.Tel;
                m.Status = value.Status;
            }
            _context.SaveChanges();
            return m;

        }

        public Member PutStatus(int id)//לשאול אם לשלוח ספר ולחסוך חיפוש
        {
            Member m = _context.Members.Find(id);
            m.Status = !m.Status;
            _context.SaveChanges();
            return m;

        }

        public Member Delete(int id)
        {
            Member m = _context.Members.Find(id);
            if (m != null)
                _context.Members.Remove(m);
            _context.SaveChanges();
            return m;
        }

    }
}
