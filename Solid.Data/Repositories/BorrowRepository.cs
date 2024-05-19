using Solid.Core.Repositories;
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
            return await _context.Borrows
                .Include(b => b.Member)
                .Include(b => b.Books).
                ThenInclude(book => book.Title)
                .ToListAsync();
        }



        public async Task<Borrow> GetByIdAsync(int id)
        {
            return await _context.Borrows.Include(b => b.Member).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Borrow> AddAsync(Borrow borrow)
        {
            _context.Borrows.Add(borrow);
            await _context.SaveChangesAsync();
            return borrow;
        }

        public async Task<Borrow> PutAsync(int id, Borrow value)
        {
            var borrow = await _context.Borrows.FirstOrDefaultAsync(b => b.Id == id);
            if (borrow != null)
            {
                borrow.MemberId = value.MemberId;
                borrow.Date = DateTime.Today;
                borrow.Status = value.Status;
                borrow.Books=new List<Book>();
                await _context.SaveChangesAsync();
            }
            return borrow;
        }

        public async Task<Borrow> PutStatusAsync(int id)
        {
            var borrow = await _context.Borrows.FirstOrDefaultAsync(b => b.Id == id);
            if (borrow != null)
            {
                borrow.Status = !borrow.Status;
                await _context.SaveChangesAsync();
            }
            return borrow;
        }

        public async Task<Borrow> AddBookToBorrowAsync(int borrowId, int bookId)
        {
            var borrow = await _context.Borrows.Include(b => b.Books).FirstOrDefaultAsync(b => b.Id == borrowId);
            if (borrow != null)
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
                if (book != null)
                {
                    book.IsBorrowed = true; // Mark the book as borrowed
                    borrow.Books.Add(book);
                    await _context.SaveChangesAsync();
                }
            }
            return borrow;
        }

        public async Task<Borrow> RemoveBookFromBorrowAsync(int borrowId, int bookId)
        {
            var borrow = await _context.Borrows.Include(b => b.Books).FirstOrDefaultAsync(b => b.Id == borrowId);
            if (borrow != null)
            {
                var bookToRemove = await _context.Books.FirstOrDefaultAsync(b => b.Id == bookId);
                if (bookToRemove != null)
                {
                    bookToRemove.IsBorrowed = false; 
                    borrow.Books.Remove(bookToRemove);
                    await _context.SaveChangesAsync();
                }
            }
            return borrow;
        }

    }
}
