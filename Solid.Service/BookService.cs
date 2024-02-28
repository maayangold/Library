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
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository; 
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        } 
        public Book Add(Book book)
        {
            return _bookRepository.Add(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            //לוגיקה עסקית
            //var books = _bookRepository.GetBooks();

            //return books.Where(u => u.Name.Contains(text));
            return _bookRepository.GetBooks();
        }
        public Book GetById(int id)
        {
            return _bookRepository.GetById(id);
        }

        public Book Put(int id, Book value)
        {
            return _bookRepository.Put(id, value);


        }

        public Book PutStatus(int id)
        {

            return _bookRepository.PutStatus(id);
        }

        public Book Delete(int id)
        {
            return _bookRepository.Delete(id);
        }
    }

}
