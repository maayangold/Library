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
            m.Status = true;
            m.Borrows = new List<Borrow>();
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
        public async Task<Borrow> BorrowBooksAsync(int memberId, List<int> bookIds)
        {
            var member = await _context.Members.Include(m => m.Borrows).FirstOrDefaultAsync(m => m.Id == memberId);
            if (member == null)
            {
                // Handle member not found error
                throw new ArgumentException("Member not found");
            }

            var booksToBorrow = await _context.Books.Where(b => bookIds.Contains(b.Id) && !b.IsBorrowed).ToListAsync();
            if (booksToBorrow.Count != bookIds.Count)
            {
                // Handle case where some books were not found or already borrowed
                throw new ArgumentException("Some books are not available for borrowing");
            }

            var borrow = new Borrow
            {
                Date = DateTime.UtcNow,
                Status = true, // Assuming borrowed status is active
                MemberId = memberId,
                Books = booksToBorrow
            };

            _context.Borrows.Add(borrow);

            foreach (var book in booksToBorrow)
            {
                book.IsBorrowed = true;
            }

            await _context.SaveChangesAsync();

            return borrow;
        }
        public async Task<Member> PutStatusAsync(int id)
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
