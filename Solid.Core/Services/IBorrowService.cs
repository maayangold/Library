using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.Services
{
    public interface IBorrowService
    {
         IEnumerable<Borrow> GetAllBorrows();
    }
}



