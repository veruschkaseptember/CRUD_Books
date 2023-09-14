using Microsoft.EntityFrameworkCore;

namespace CRUD_Books.Models
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) //constructor class
        { }

        public DbSet<Book> Books { get; set; }
    }
}

