using AutoMapper;
using System;
using System.Linq;
using WebApiBookStore.DbOperations;
using WebApiBookStore.Entities;

namespace WebApiBookStore.Application.GenreOperations.Commands.CreateGenres
{
    public class CreateGenresCommand
    {
        public CreateGenreModel Model { get; set; }
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public CreateGenresCommand(BookContext context, IMapper mapper)
        {
            
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var createGenre = _context.Genres.SingleOrDefault(x => x.GenreName == Model.GenreName);
            if (createGenre is not null)
            {
                throw new InvalidOperationException("Kategori zaten mevcut");
            }
            createGenre = _mapper.Map<Genre>(Model);
            _context.Genres.Add(createGenre);
            _context.SaveChanges();
        }

        public class CreateGenreModel
        {
            public string GenreName { get; set; }
            
        }
    }
}

