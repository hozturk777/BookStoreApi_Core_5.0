using System;
using System.Collections.Generic;
using System.Linq;
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

        public BookController(BookContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetIdBook(int id)
        {
            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
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
            CreateBooksQuery query = new CreateBooksQuery(_context);
            try
            {
                query.Model = NewBook;
                query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookViewModel UpdateBook)
        {
            
            try
            {
                UpdateBooksQuery query = new UpdateBooksQuery(_context);
                query.BookId = id;
                query.Model = UpdateBook;
                query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBooksQuery query = new DeleteBooksQuery(_context);
                query.BookId = id;
                query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
    }
}