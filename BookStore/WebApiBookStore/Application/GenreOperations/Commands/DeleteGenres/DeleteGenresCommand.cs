using System.Linq;
using System;
using WebApiBookStore.DbOperations;

namespace WebApiBookStore.Application.GenreOperations.Commands.DeleteGenres
{
    public class DeleteGenresCommand
    {
        private readonly BookContext _context;
        public int ID { get; set; }
        public DeleteGenresCommand(BookContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.GenreID == ID);
            if (genre is null)
            {
                throw new InvalidOperationException("Böyle bir kategori yok");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}
