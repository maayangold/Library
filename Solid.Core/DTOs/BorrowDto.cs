using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Core.DTOs
{
    public class BorrowDto
    {
        public int Id { get; set; }
        //Foreign Key
        public int MemberId { get; set; }       
       
        public bool Status { get; set; }
    }
}
