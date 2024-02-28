using AutoMapper;
using AutoMapper.Execution;
using Library.Entities;
using Library.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Solid.Core.DTOs;
using Solid.Core.Services;
using Solid.Service;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using static Humanizer.In;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var books = await _bookService.GetAllBooksAsync();
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
                return NotFound();
            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BookPostModel book)
        {
            var bookToAdd = _mapper.Map<Book>(book);
            var newbook = await _bookService.AddAsync(bookToAdd);
            var bookDto = _mapper.Map<BookDto>(newbook);
            return Ok(bookDto);
        }


        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BookPostModel book)
        {
            var bookToUpdate = _mapper.Map<Book>(book);
            var newbook = await _bookService.PutAsync(id, bookToUpdate);
            if (newbook == null)
                return NotFound();

            var bookDto = _mapper.Map<BookDto>(newbook);

            return Ok(bookDto);

        }
        // PUT api/<BooksController>/5
        [HttpPut("{id}/status")]
        public async Task<ActionResult> PutStatus(int id)
        {
            var bookToUpdateS = await _bookService.PutStatusAsync(id);
            if (bookToUpdateS == null)
                return NotFound();
            var bookDto = _mapper.Map<BookDto>(bookToUpdateS);

            return Ok(bookDto);

        }
        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookService.DeleteAsync(id);
            if (bookToDelete == null)
                return NotFound();
            var bookDto = _mapper.Map<BookDto>(bookToDelete);
            return Ok(bookDto);
        }
    }
}
