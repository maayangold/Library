using Library.Entities;
using Solid.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IBorrowService
    {
        public Task<IEnumerable<Borrow>> GetAllBorrowsAsync();

        public Task<Borrow> GetByIdAsync(int id);

        public Task<Borrow> AddAsync(Borrow b);

        public Task<Borrow> PutAsync(int id, Borrow value);

        public Task<Borrow> PutStatusAsync(int id);

        public Task<Borrow> DeleteAsync(int id);


    }
}



