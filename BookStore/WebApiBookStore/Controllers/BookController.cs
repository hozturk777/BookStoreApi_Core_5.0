using System;
using System.Collections.Generic;

using System.Linq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebApiBookStore.BookOperations.CreateBooks;
using WebApiBookStore.BookOperations.DeleteBooks;
using WebApiBookStore.BookOperations.GetBookDetails;
using WebApiBookStore.BookOperations.GetBooks;
using WebApiBookStore.BookOperations.UpdateBooks;
using WebApiBookStore.DbOperations;
using static WebApiBookStore.BookOperations.CreateBooks.CreateBooksQuery;
using static WebApiBookStore.BookOperations.UpdateBooks.UpdateBooksQuery;

namespace WebApi.AddController
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public BookController(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetIdBook(int id)
        {
            BookDetailViewModel result;
    
                GetBookDetailQuery query = new GetBookDetailQuery(_context, _mapper);
                query.BookId = id;

                GetBooksDetalValidator validator = new GetBooksDetalValidator();
                validator.ValidateAndThrow(query);

                result = query.Handle();
            

            return Ok(result);
        }
        //[HttpGet]
        //public Book Get([FromQuery] string id)
        //{
        //    var book = BookList.Where(book => book.Id == Convert.ToInt32(id)).SingleOrDefault();
        //    return (book);
        //}


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel NewBook)
        {
            CreateBooksQuery command = new CreateBooksQuery(_context, _mapper);
 
            command.Model = NewBook;

            CreateBooksValidator validator = new CreateBooksValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

                //if (!result.IsValid)
                //{
                //    foreach ( var item in result.Errors)
                //    {
                //        Console.WriteLine("Property : " + item.PropertyName + " - Error Message : " + item.ErrorMessage);
                //    }
                //}

      

            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel UpdateBook)
        {
            
      
                UpdateBooksQuery query = new UpdateBooksQuery(_context);
                query.BookId = id;
                query.Model = UpdateBook;

                UpdateBooksValidator validator = new UpdateBooksValidator();
                validator.ValidateAndThrow(query);

                query.Handle();
   

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {

                DeleteBooksQuery query = new DeleteBooksQuery(_context);
                query.BookId = id;

                DeleteBooksValidator validator = new DeleteBooksValidator();
                validator.ValidateAndThrow(query);

                query.Handle();
        

            return Ok();
        }
    }
}