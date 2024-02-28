using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;

namespace Solid.Core.Repositories
{
    public interface IBorrowRepository
    {
        public Task<IEnumerable<Borrow>> GetBorrowsAsync();


        public Task<Borrow> GetByIdAsync(int id);

        public Task<Borrow> AddAsync(Borrow b);
        // Post

        public Task<Borrow> PutAsync(int id, Borrow value);

        public Task<Borrow> PutStatusAsync(int id);
        //????/להפוך סטטוס השאלה ללא קיים או למחוק
        public Task<Borrow> DeleteAsync(int id);
    }
}
