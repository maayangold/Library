using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace Solid.Data.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;
        public MemberRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Member>> GetMembersAsync()
        {
            return await _context.Members.ToListAsync();
        }
        public async Task<Member> GetByIdAsync(int id)
        {
            return await _context.Members.FirstAsync(b => b.Id == id);
        }

        public async Task<Member> AddAsync(Member m)
        {
            _context.Members.Add(m);
            await _context.SaveChangesAsync();
            return m;
        }


        public async Task<Member> PutAsync(int id, Member value)
        {
            Member m = await _context.Members.FirstAsync(b => b.Id == id);
            if (m != null)
            {
                m.Name = value.Name;
                m.Tel = value.Tel;
                m.Status = value.Status;
            }
            await _context.SaveChangesAsync();
            return m;

        }

        public async Task<Member> PutStatusAsync(int id)//לשאול אם לשלוח ספר ולחסוך חיפוש
        {
            Member m = await _context.Members.FirstAsync(b => b.Id == id);
            m.Status = !m.Status;
            await _context.SaveChangesAsync();
            return m;

        }

        public async Task<Member> DeleteAsync(int id)
        {
            Member m = await _context.Members.FirstAsync(b => b.Id == id);
            if (m != null)
                _context.Members.Remove(m);
            await _context.SaveChangesAsync();
            return m;
        }

    }
}
