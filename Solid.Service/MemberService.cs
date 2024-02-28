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
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
        public async Task<Member> AddAsync(Member b)
        {
            return await _memberRepository.AddAsync(b);
        }
        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            return await _memberRepository.GetMembersAsync();
        }
        public async Task<Member> GetByIdAsync(int id)
        {
            return await _memberRepository.GetByIdAsync(id);
        }

        public async Task<Member> PutAsync(int id, Member value)
        {
            return await _memberRepository.PutAsync(id, value);


        }

        public async Task<Member> PutStatusAsync(int id)
        {

            return await _memberRepository.PutStatusAsync(id);
        }

        public async Task<Member> DeleteAsync(int id)
        {
            return await _memberRepository.DeleteAsync(id);
        }


    }
}
