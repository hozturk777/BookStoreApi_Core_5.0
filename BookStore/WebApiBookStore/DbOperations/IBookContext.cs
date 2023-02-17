using Microsoft.EntityFrameworkCore;
using WebApiBookStore.Entities;

namespace WebApiBookStore.DbOperations
{
    public interface IBookContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Authors { get; set; }

        int SaveChanges();
    }
}
