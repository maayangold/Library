namespace Library.Entities
{
    public class Borrow
    {
        private static int _id = 1;
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public bool Status { get; set; }
        //public DateOnly Date { get; set; }
        public Borrow(int memberId, int bookId, bool status)//,DateOnly date
        {
            Id = _id++;
            MemberId = memberId;
            BookId = bookId;
            Status = status;
            //Date = date;
        }
    }
}
