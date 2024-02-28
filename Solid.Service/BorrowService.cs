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
    public class BorrowService:IBorrowService
    {
        private readonly IBorrowRepository _borrowRepository;
        public BorrowService(IBorrowRepository borrowRepository)
        {
            _borrowRepository = borrowRepository;
        }
        public Borrow Add(Borrow b)
        {
            return _borrowRepository.Add(b);
        }

        public IEnumerable<Borrow> GetAllBorrows()
        {
            return _borrowRepository.GetBorrows();
        }
        public Borrow GetById(int id)
        {
            return _borrowRepository.GetById(id);
        }

        public Borrow Put(int id, Borrow value)
        {
            return _borrowRepository.Put(id, value);


        }

        public Borrow PutStatus(int id)
        {

            return _borrowRepository.PutStatus(id);
        }

        public Borrow Delete(int id)
        {
            return _borrowRepository.Delete(id);
        }
    }
}
