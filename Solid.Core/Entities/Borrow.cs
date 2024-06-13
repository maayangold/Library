
namespace Library.Entities
{
    public class Borrow
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        //Foreign Key
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public List<Book> Books { get; set; } // Represents the books borrowed in this borrow instance
        public bool Status { get; set; }

    }
}
