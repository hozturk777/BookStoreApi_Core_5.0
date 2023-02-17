using AutoMapper;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiBookStore.Application.BookOperations.Commands.CreateBooks;
using WebApiBookStore.DbOperations;
using WebApiBookStore.Entities;
using WebApiBookStore.UnitTests.TestSetup;
using Xunit;
using static WebApiBookStore.Application.BookOperations.Commands.CreateBooks.CreateBooksQuery;

namespace WebApiBookStore.UnitTests.Application.BookOperations.Commands.CreateBooks
{
    public class CreateBooksCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public CreateBooksCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldeBeReturn()
        {
            //arrange (HAZIRLIK)
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldeBeReturn", PageCount = 150, PublishDate = new DateTime(1220, 03, 21), GenreId = 1 };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBooksQuery command = new CreateBooksQuery(_context, _mapper);
            command.Model = new CreateBookModel() { Title = book.Title };

            //act && assert (ÇALIŞTIRMA && DOĞRULAMA)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Bu Kitap Zaten Mevcut.");
            
        }
    }
}
