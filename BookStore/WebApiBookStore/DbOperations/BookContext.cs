using Microsoft.EntityFrameworkCore;
using WebApi;

namespace WebApiBookStore.DbOperations
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        { }
        public DbSet<Book> Books { get; set; }
    }
}
