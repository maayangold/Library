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
        public string MemberName { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public List<BookDto> Books { get; set; }
    }
}

