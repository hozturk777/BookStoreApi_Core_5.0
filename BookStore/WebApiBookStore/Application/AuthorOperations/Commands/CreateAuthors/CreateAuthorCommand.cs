using AutoMapper;
using System.Linq;
using System;
using WebApiBookStore.DbOperations;
using WebApiBookStore.Entities;

namespace WebApiBookStore.Application.AuthorOperations.Commands.CreateAuthors
{
    public class CreateAuthorCommand
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model { get; set; }
        public CreateAuthorCommand(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name);
            if (author is not null)
            {
                throw new InvalidOperationException("Bu yazar zaten ekli!");
            }
            author = _mapper.Map<Author>(Model);
            _context.Add(author);
            _context.SaveChanges();
        }

        public class CreateAuthorModel
        {
            public string Name { get; set; }
            public string SurName { get; set; }
            public int DateOfBirth { get; set; }
        }
    }
}
