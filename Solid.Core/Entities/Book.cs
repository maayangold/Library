//using Microsoft.AspNetCore.Components.Web;

namespace Library.Entities
{
    public class Book
    {
        private static int _id = 1;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }
        public Book(string title, string author, string description = "", bool status = true)
        {
            Id = _id++;
            Title = title;
            Description = description;
            Author = author;
            Status = status;
        }
    }
}
