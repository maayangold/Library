namespace Library.Entities
{
    public class Borrow
    {
        public int Id { get; set; }
        //Foreign Key
        public int MemberId { get; set; }     
        public Member Member { get; set; }

       //public DateTime Date { get; set; }

        //Many-To-Many
        public List<Book> Books { get; set; }

        public bool Status { get; set; }
      
    }
}
