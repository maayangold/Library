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
        public List<Borrow> GetBorrows()
        {
            return _context.Borrows.Include(b => b.Member).Include(b => b.Books).ToList();
        }

        public Borrow GetById(int id)
        {
            return _context.Borrows.Find(id);
        }

        public Borrow Add(Borrow b)
        {
            _context.Borrows.Add(b);
            _context.SaveChanges();
            return b;
        }


        public Borrow Put(int id, Borrow value)
        {
            Borrow b = _context.Borrows.Find(id);
            if (b != null)
            {
                b.Member = value.Member;
                b.MemberId = value.Member.Id;
                b.Books = value.Books;
                b.Date = value.Date;
                b.Status = value.Status;
            }
            _context.SaveChanges();
            return b;

        }

        public Borrow PutStatus(int id)//לשאול אם לשלוח ספר ולחסוך חיפוש
        {
            Borrow b = _context.Borrows.Find(id);
            b.Status = !b.Status;
            _context.SaveChanges();
            return b;

        }

        public Borrow Delete(int id)
        {
            Borrow b = _context.Borrows.Find(id);
            if (b != null)
                _context.Borrows.Remove(b);
            _context.SaveChanges();
            return b;
        }
    }
}
