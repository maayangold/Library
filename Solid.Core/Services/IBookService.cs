using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<Book>> GetAllBooksAsync();

        public Task<Book> GetByIdAsync(int id);

        public Task<Book> AddAsync(Book Book);

        public Task<Book> PutAsync(int id, Book value);

        public Task<Book> PutStatusAsync(int id);

        public Task<Book> DeleteAsync(int id);

    }
}
