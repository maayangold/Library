using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;
using Solid.Service;
using System.Collections.Generic;
using Solid.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//לקוח יכול לשאול ספר כמה פעמים!
//בגלל זה לא צריך מפתח יחודי של ספר  ומשאיל
namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        //static int id = 1;
        //static List<Member> members=new List<Member> { new Member(id++,"moshe",true), new Member(id++, "haim",true) , new Member(id++, "tuvia", true) };
        private readonly MemberService _memberService;
        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }


        // GET: api/<MembersController>
        [HttpGet]
        public IEnumerable<Member> Get()
        {
            return _memberService.GetAllMembers();
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Member m = _memberService.GetById(id);
            if (m == null)
                return NotFound();
            return Ok(m);
        }

        // POST api/<MembersController>
        [HttpPost]
        public void Post([FromBody] Member value)
        {
            _memberService.GetAllMembers().Append(new Member(value.Name, true, value.Tel));
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Member value)
        {
            Member m = _memberService.GetById(id);
            if (m == null)
                return NotFound();
            
            //m.Name = value.Name;
            //m.Tel = value.Tel;
            //m.Status = value.Status;

            //_memberService.GetAllMembers().Append(m);
            return Ok(_memberService.Put(id,value));

        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Member m = _memberService.GetById( id);
            if (m == null)
                return NotFound();
      
      return Ok(_memberService.Delete(id));
        }
    }//[HttpPut("{id}/status")]
     //public ActionResult PutStatus(int id)
     //{
     //    Member m = members.Find(member => member.Id == id);
     //    if (m == null)
     //        return NotFound();
     //    members.Remove(m);
     //    m.Status = !m.Status;
     //    members.Add(m);
     //    return Ok();
     //}
}
