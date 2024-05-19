
namespace Library.Entities
{
    public class Borrow
    {
        public int Id { get; set; }
        //Foreign Key
       public DateTime Date { get; set; }
        public int MemberId { get; set; }     
        public Member Member { get; set; }

        //Many-To-Many
        public List<Book> Books { get; set; } // Represents the books borrowed in this borrow instance
        public bool Status { get; set; }
      
    }
}
