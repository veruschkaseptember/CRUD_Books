//defines the BookDbContext class, which is a subclass of DbContext provided by Entity Framework Core

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

// extends the DbContext class and provides a constructor to configure the context options.
// The DbSet<Book> property is used to interact with the Books table in the database, allowing
// for CRUD operations on the Book entity
// BookDbContext class is defined within the CRUD_Books.Models namespace
// class has a constructor that accepts an instance of DbContextOptions<BookDbContext>
// constructor is used to configure the database context options, such as the
// connection string and other settings
// constructor calls the base class constructor (base(options)) to initialize the DbContext
// with the provided options
// class has a DbSet<Book> property named Books. property represents the collection of Book
// entities in the database and allows for querying, inserting, updating, and deleting books