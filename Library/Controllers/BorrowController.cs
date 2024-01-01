using Library.Entities;
using Microsoft.AspNetCore.Mvc;
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

        private readonly BorrowService _borrowService;
        public BorrowsController(BorrowService borrowService)
        {
            _borrowService = borrowService;
        }

        // GET: api/<BorrowsController>
        [HttpGet]
        public IEnumerable<Borrow> Get()
        {
            return _borrowService.GetAllBorrows();
        }

        // GET api/<BorrowsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Borrow b = _borrowService.GetAllBorrows().Find(x => x.Id == id);
            if (b == null)
                return NotFound();
            return Ok(b);
        }

        // POST api/<BorrowsController>
        [HttpPost]
        public void Post([FromBody] Borrow value)
        {

            _borrowService.GetAllBorrows().Add(new Borrow(value.MemberId, value.BookId, true));
        }

        // PUT api/<BorrowsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Borrow value)
        {
            Borrow b = _borrowService.GetAllBorrows().Find(x => x.Id == id);
            if (b == null)
                return NotFound();
            _borrowService.GetAllBorrows().Remove(b);

            b.MemberId = value.MemberId;
            b.BookId = value.BookId;
            b.Status = value.Status;
            _borrowService.GetAllBorrows().Add(b);
            return Ok();

        }
        // PUT api/<BorrowsController>/5
        [HttpPut("{id}/status")]
        public ActionResult PutStats(int id)
        {
            Borrow b = _borrowService.GetAllBorrows().FirstOrDefault(x => x.Id == id);

            if (b == null)
                return NotFound();
            _borrowService.GetAllBorrows().Remove(b);
            b.Status = !b.Status;
            _borrowService.GetAllBorrows().Add(b);
            return Ok();


        }

        //// DELETE api/<BorrowsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
