using Library.Entities;
using Microsoft.AspNetCore.Mvc;
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
            Borrow b = _borrowService.GetById(id);
            if (b == null)
                return NotFound();
            return Ok(b);
        }

        // POST api/<BorrowsController>
        [HttpPost]
        public ActionResult Post([FromBody] Borrow value)
        {

            return Ok(_borrowService.Add(value));
        }

        // PUT api/<BorrowsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Borrow value)
        {
            Borrow b = _borrowService.GetById(id);
            if (b == null)
                return NotFound();
         
            return Ok(_borrowService.Put(id,value));

        }
        // PUT api/<BorrowsController>/5
        [HttpPut("{id}/status")]
        public ActionResult PutStats(int id)
        {
            Borrow b = _borrowService.GetById(id);
            if (b == null)
                return NotFound();         
            return Ok(_borrowService.PutStatus(id));
            


        }

      
    }
}
