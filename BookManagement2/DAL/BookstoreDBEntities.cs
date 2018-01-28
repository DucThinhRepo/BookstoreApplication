using BookManagement2.Models;
using System.Data.Entity;

namespace BookManagement2.DAL
{
    public partial class BookstoreDBEntities : DbContext
    {
        public BookstoreDBEntities(): base("BookstoreDBEntities")
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Borrow> Borrows { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Major> Majors { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}