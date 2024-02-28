using Library.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using static System.Reflection.Metadata.BlobBuilder;
using System.Linq;
using Solid.Service;
using System.Collections.Generic;
using Solid.Core.Services;
using AutoMapper;
using Solid.Core.DTOs;
using AutoMapper.Execution;
using Library.Models;
using System.Diagnostics.Metrics;
using Member = Library.Entities.Member;//help


//לקוח יכול לשאול ספר כמה פעמים!
//בגלל זה לא צריך מפתח יחודי של ספר  ומשאיל
namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public MemberController(IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }


        // GET: api/<MembersController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var members = await _memberService.GetAllMembersAsync();
            var membersDto = _mapper.Map<IEnumerable<MemberDto>>(members);

            return Ok(membersDto);
        }

        // GET api/<MembersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
                return NotFound();
            var memberDto = _mapper.Map<MemberDto>(member);
            return Ok(memberDto);
        }

        // POST api/<MembersController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MemberPostModel member)

        {
            var memberToAdd = _mapper.Map<Member>(member);
            var newMember = await _memberService.AddAsync(memberToAdd);
            return Ok(newMember);
        }

        // PUT api/<MembersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MemberPostModel member)
        {
            var memberToUpdate = _mapper.Map<Member>(member);
            var newMember = await _memberService.PutAsync(id, memberToUpdate);
            if (newMember == null)
                return NotFound();
            return Ok(newMember);

        }

        // DELETE api/<MembersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var memberToDelete = await _memberService.DeleteAsync(id);
            if (memberToDelete == null)
                return NotFound();

            return Ok(memberToDelete);
        }
    }

}
