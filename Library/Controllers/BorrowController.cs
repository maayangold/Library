using AutoMapper;
using Library.Entities;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Services;
using Solid.Service;
using System.Collections.Generic;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowsController : ControllerBase
    {

        private readonly IBorrowService _borrowService;
        private readonly IMapper _mapper;
        public BorrowsController(IBorrowService borrowService, IMapper mapper)
        {
            _borrowService = borrowService;
            _mapper = mapper;
        }

        // GET: api/<BorrowsController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var borrows = await _borrowService.GetAllBorrowsAsync();
            var borrowsDto = _mapper.Map<IEnumerable<BorrowDto>>(borrows);

            return Ok(borrowsDto);
        }

        // GET api/<BorrowsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var borrow = await _borrowService.GetByIdAsync(id);
            if (borrow == null)
                return NotFound();
            var borrowDto = _mapper.Map<BorrowDto>(borrow);
            return Ok(borrowDto);
        }

        // POST api/<BorrowsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BorrowPostModel borrow)

        {
            var borrowToAdd = _mapper.Map<Borrow>(borrow);
            var newborrow = await _borrowService.AddAsync(borrowToAdd);
            return Ok(newborrow);
        }

        // PUT api/<BorrowsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] BorrowPostModel borrow)
        {
            var borrowToUpdate = _mapper.Map<Borrow>(borrow);
            var newborrow = await _borrowService.PutAsync(id, borrowToUpdate);
            if (newborrow == null)
                return NotFound();
            return Ok(newborrow);

        }
        // PUT api/<BorrowsController>/5
        [HttpPut("{id}/status")]
        public async Task<ActionResult> PutStats(int id)
        {
            var borrowToUpdateS = await _borrowService.PutStatusAsync(id);
            if (borrowToUpdateS == null)
                return NotFound();
            return Ok(borrowToUpdateS);



        }
        //[HttpPut("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var borrowToDelete = await _borrowService.DeleteAsync(id);
        //    if (borrowToDelete == null)
        //        return NotFound();
        //    return Ok(borrowToDelete);



        //}


    }
}
