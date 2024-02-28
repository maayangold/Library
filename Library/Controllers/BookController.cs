using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Solid.Service;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;
        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookService.GetAllBooks();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Book b = _bookService.GetById(id);
            if (b == null)
                return NotFound();
            return Ok(b);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult Post([FromBody] Book b)
        {
            return Ok(_bookService.Add(b));
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book value)
        {
            Book b = _bookService.GetById(id);
            if (b == null)
                return NotFound();
           
            return Ok( _bookService.Put(id,value));

        }
        // PUT api/<BooksController>/5
        [HttpPut("{id}/status")]
        public ActionResult PutStatus(int id)
        {
            Book b = _bookService.GetById(id);
            if (b == null)
                return NotFound();
            return Ok( _bookService.PutStatus(id));

        }
        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Book b = _bookService.GetById(id);
            if (b == null)
                return NotFound();
            return Ok(_bookService.Delete(id));
        }
    }
}
