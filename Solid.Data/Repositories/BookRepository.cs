using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Entities;
using Solid.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Solid.Data.Repositories
{
    public class BookRepository : IBookRepository

    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FirstAsync(b => b.Id == id);
        }

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }


        public async Task<Book> PutAsync(int id, Book value)
        {
            var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book != null)
            {
                book.IsBorrowed = value.IsBorrowed;
                book.Author = value.Author;
                book.Title = value.Title;
                book.Description = value.Description;
                await _context.SaveChangesAsync();
            }
            return book;
        }
        public async Task<Book> PutStatusAsync(int id)//לשאול אם לשלוח ספר ולחסוך חיפוש
        {
            Book book = await _context.Books.FirstAsync(b => b.Id == id);
            book.IsBorrowed = !book.IsBorrowed;
            await _context.SaveChangesAsync();
            return book;

        }

        public async Task<Book> DeleteAsync(int id)
        {
            Book book = _context.Books.Find(id);
            if (book != null)
                _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }


    }


}