namespace Library.Entities
{
    public class Member
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public bool Status { get; set; }
        public Member(string name, bool status, string tel = "")
        {
            Id = _id++;
            Name = name;
            Tel = tel;
            Status = status;
        }
    }
}
