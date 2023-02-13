using Microsoft.EntityFrameworkCore;
using WebApiBookStore.Entities;

namespace WebApiBookStore.DbOperations
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
