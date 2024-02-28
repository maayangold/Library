using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using Library.Entities;
using Solid.Core.Services;

namespace Solid.Data.Repositories
{
    public class BookRepository : IBookRepository

    {
        private readonly DataContext _context;
        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public Book Add(Book Book)
        {
            _context.Books.Add(Book);
            _context.SaveChanges();
            return Book;
        }


        public Book Put(int id, Book value)
        {
            Book book = _context.Books.Find(id);
            if (book != null)
            {
                book.Status = value.Status;
                book.Author = value.Author;
                book.Title = value.Title;
                book.Description = value.Description;
            }
            _context.SaveChanges();
            return book;

        }

        public Book PutStatus(int id)//לשאול אם לשלוח ספר ולחסוך חיפוש
        {
            Book book = _context.Books.Find(id);
            book.Status = !book.Status;
            _context.SaveChanges();
            return book;

        }

        public Book Delete(int id)
        {
            Book book = _context.Books.Find(id);
            if (book != null)
                _context.Books.Remove(book);
            _context.SaveChanges();
            return book;
        }
    }


}
