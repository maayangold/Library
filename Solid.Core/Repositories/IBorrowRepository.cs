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
        List<Borrow> GetBorrows();
       

        public Borrow GetById(int id)
      ;

        public Borrow Add(Borrow b);
        // public Book Post(Book b);

        public Borrow Put(int id, Borrow value);

        public Borrow PutStatus(int id);
        public Borrow Delete(int id);
    }
}
