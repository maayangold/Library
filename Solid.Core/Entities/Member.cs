namespace Library.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public bool Status { get; set; }
        public Borrow Borrow { get; set; }
    
    }
}
