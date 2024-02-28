using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace Solid.Core.Repositories
{
    public interface IBookRepository
    {
        public List<Book> GetBooks();

        public Book GetById(int id)
      ;

        public Book Add(Book Book);
       // public Book Post(Book b);

        public Book Put(int id, Book value);

        public Book PutStatus(int id);
        public Book Delete(int id);

    }
}
