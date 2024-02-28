//using Microsoft.AspNetCore.Components.Web;

namespace Library.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        //Many-To-Many
        public List<Borrow> Borrows { get; set; }
        public bool Status { get; set; }
         

    }
}
