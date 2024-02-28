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
        public Task<IEnumerable<Book>> GetBooksAsync();

        public Task<Book> GetByIdAsync(int id);
        //  Post
        public Task<Book> AddAsync(Book Book);

        public Task<Book> PutAsync(int id, Book value);

        public Task<Book> PutStatusAsync(int id);

        public Task<Book> DeleteAsync(int id);

    }
}
