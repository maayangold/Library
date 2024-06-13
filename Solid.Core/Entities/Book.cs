//using Microsoft.AspNetCore.Components.Web;

namespace Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool IsBorrowed { get; set; }
        public List<Borrow> Borrows { get; set; }

    }
}
