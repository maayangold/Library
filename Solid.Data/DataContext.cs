using Library.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Data
{
    public class DataContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Member> Members { get; set; }
        //public DataContext()
        //{
        //    //List<Book> books = new List<Book> { new Book("bla", ""), new Book("blu", ""), new Book("bli", "") };
        //    //List<Borrow> borrows = new List<Borrow> { new Borrow(1, 2, true), new Borrow(2, 1, true), new Borrow(3, 3, true) };
        //    //List<Member> members = new List<Member> { new Member("moshe", true), new Member("haim", true), new Member("tuvia", true) };

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=library_db");
        }
       
    }
}
