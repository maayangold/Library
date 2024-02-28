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
    public class BorrowRepository : IBorrowRepository
    {
        private readonly DataContext _context;
        public BorrowRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Borrow>> GetBorrowsAsync()
        {
            return await _context.Borrows.Include(b => b.Member).ToListAsync();
        }

        public async Task<Borrow> GetByIdAsync(int id)
        {
            return await _context.Borrows.Include(b => b.Member).FirstAsync(b => b.Id == id);
        }

        public async Task<Borrow> AddAsync(Borrow b)
        {
            _context.Borrows.Add(b);
            await _context.SaveChangesAsync();
            return b;
        }


        public async Task<Borrow> PutAsync(int id, Borrow value)
        {
            Borrow b = await _context.Borrows.FirstAsync(b => b.Id == id);
            if (b != null)
            {

                b.MemberId = value.MemberId;
                //b.Date = DateTime.Today;
                b.Status = value.Status;
            }
            await _context.SaveChangesAsync();
            return b;

        }

        public async Task<Borrow> PutStatusAsync(int id)//לשאול אם לשלוח לא רק id ולחסוך חיפוש
        {
            Borrow b = await _context.Borrows.FirstAsync(b => b.Id == id);
            b.Status = !b.Status;
            await _context.SaveChangesAsync();
            return b;

        }
        //לא בשימוש
        public async Task<Borrow> DeleteAsync(int id)
        {
            Borrow b = await _context.Borrows.FirstAsync(b => b.Id == id);
            if (b != null)
                _context.Borrows.Remove(b);
            await _context.SaveChangesAsync();
            return b;
        }
    }
}
