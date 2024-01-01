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
    public class BookRepository : IBookRepository

    {
        private readonly DataContext _context;
        public List<Book> GetBooks()
        {
            return _context.Books;
        }
    }
}
