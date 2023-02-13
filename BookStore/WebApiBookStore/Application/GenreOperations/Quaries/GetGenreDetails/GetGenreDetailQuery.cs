﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiBookStore.DbOperations;

namespace WebApiBookStore.Application.GenreOperations.Quaries.GetGenreDetails
{
    public class GetGenreDetailQuery
    {
        private BookContext _context;
        private IMapper _mapper;
        public int ID { get; set; }

        public GetGenreDetailQuery(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GenreDetailModel Handle()
        {
            var genredetails = _context.Genres.Where(x => x.IsActive && x.GenreID == ID).SingleOrDefault();

            if (genredetails is null)
            {
                throw new InvalidOperationException("Bulunamadı");
            }

            return _mapper.Map<GenreDetailModel>(genredetails);
        }
        public class GenreDetailModel
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
