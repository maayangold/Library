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

        public List<Book> GetAllBooks()//string? text = "")
        {
            //לוגיקה עסקית
            //var books = _bookRepository.GetBooks();

            //return books.Where(u => u.Name.Contains(text));
            return _bookRepository.GetBooks();
        }
    }
}
