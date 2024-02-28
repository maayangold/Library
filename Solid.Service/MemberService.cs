using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using Solid.Core.Services;

namespace Solid.Service
{
    public class MemberService:IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public Member Add(Member b)
        {
            return _memberRepository.Add(b);
        }
        public IEnumerable<Member> GetAllMembers()
        {
            return _memberRepository.GetMembers();
        }
        public Member GetById(int id)
        {
            return _memberRepository.GetById(id);
        }

        public Member Put(int id, Member value)
        {
            return _memberRepository.Put(id, value);


        }

        public Member PutStatus(int id)
        {

            return _memberRepository.PutStatus(id);
        }

        public Member Delete(int id)
        {
            return _memberRepository.Delete(id);
        }
    }
}
