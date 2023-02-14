using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiBookStore.DbOperations;

namespace WebApiBookStore.Application.AuthorOperations.Quaries.GetAuthorDetails
{
    public class GetAuthorDetailQuery
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;
        public int ID { get; set; }
        public GetAuthorDetailQuery(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorDetailModel Handle()
        {
            var author = _context.Authors.Where(x => x.AuthorID == ID).SingleOrDefault();
            if (author is null)
            {
                throw new InvalidOperationException("Öyle Bir Yazar Yok!");
            }
            GetAuthorDetailModel vm = _mapper.Map<GetAuthorDetailModel>(author);

            return vm;
        }

        public class GetAuthorDetailModel
        {
            public string Name { get; set; }
            public string SurName { get; set; }
            public int DateOfBirth { get; set; }
        }
    }
}
