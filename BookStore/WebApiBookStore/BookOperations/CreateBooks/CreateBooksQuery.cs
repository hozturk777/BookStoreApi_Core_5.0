﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi;
using WebApiBookStore.DbOperations;

namespace WebApiBookStore.BookOperations.CreateBooks
{
    public class CreateBooksQuery
    {
        public CreateBookModel Model { get; set; }
        private readonly BookContext _bookContext;

        public CreateBooksQuery(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public void Handle()
        {
            var book = _bookContext.Books.SingleOrDefault(x => x.Title == Model.Title);
            if (book is not null)
            {
                throw new InvalidOperationException("Kitap Zaten Mevcut");
            }
            book = new Book();
            book.Title = Model.Title;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount;
            book.GenreId = Model.GenreId;

            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
        }
        public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreId { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }
        }
    }
}