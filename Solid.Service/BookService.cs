using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using Solid.Core.Services;
using static System.Net.Mime.MediaTypeNames;

namespace Solid.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            //לוגיקה עסקית
            //var books = _bookRepository.GetBooks();
            //return books.Where(u => u.Name.Contains(text));
            return await _bookRepository.GetBooksAsync();
        }
  
        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }
        public async Task<Book> AddAsync(Book book)
        {
            return await _bookRepository.AddAsync(book);
        }


        public async Task<Book> PutAsync(int id, Book value)
        {
            return await _bookRepository.PutAsync(id, value);


        }

        public async Task<Book> PutStatusAsync(int id)
        {

            return await _bookRepository.PutStatusAsync(id);
        }

        public async Task<Book> DeleteAsync(int id)
        {
            return await _bookRepository.DeleteAsync(id);
        }
        

    }

}
