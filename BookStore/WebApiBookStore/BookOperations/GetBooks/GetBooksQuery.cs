﻿using System;
using System.Collections.Generic;
using System.Linq;
using WebApi;
using WebApiBookStore.Common;
using WebApiBookStore.DbOperations;

namespace WebApiBookStore.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookContext _bookContext;

        public GetBooksQuery(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public List<BookViewModel> Handle()
        {
            var booklist = _bookContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BookViewModel> bvm = new List<BookViewModel>();
            foreach (var book in booklist)
            {
                bvm.Add(new BookViewModel()
                {
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyy"),
                    PageCount = book.PageCount
                });
            }
            return bvm;
        }

        public class BookViewModel
        {
            public string Title { get; set; }
            public int PageCount { get; set; }
            public String PublishDate { get; set; }
            public string Genre { get; set; }
        }
    }
}