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
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        public async Task<IEnumerable<Borrow>> GetAllBorrowsAsync()
        {
            return await _borrowRepository.GetBorrowsAsync();
        }
        public async Task<Borrow> GetByIdAsync(int id)
        {
            return await _borrowRepository.GetByIdAsync(id);
        }
        public BorrowService(IBorrowRepository borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }
        public async Task<Borrow> AddAsync(Borrow b)
        {
            return await _borrowRepository.AddAsync(b);
        }


        public async Task<Borrow> PutAsync(int id, Borrow value)
        {
            return await _borrowRepository.PutAsync(id, value);


        }

        public async Task<Borrow> PutStatusAsync(int id)
        {

            return await _borrowRepository.PutStatusAsync(id);
        }

        public async Task<Borrow> DeleteAsync(int id)
        {
            return await _borrowRepository.DeleteAsync(id);
        }
    }
}
