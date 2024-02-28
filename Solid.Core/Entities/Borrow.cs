namespace Library.Entities
{
    public class Borrow
    {
        private static int _id = 1;
        public int Id { get; set; }
        public int MemberId { get; set; }
      
        public Member Member { get; set; }
        public List<Book> Books { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
       //public Borrow(Member member,Book book, bool status)//,DateOnly date
        //{
        //    Id = _id++;
        //    Member = member;
        //    Book = book;
        //    Status = status;
        //    //Date = date;
        //}
    }
}
