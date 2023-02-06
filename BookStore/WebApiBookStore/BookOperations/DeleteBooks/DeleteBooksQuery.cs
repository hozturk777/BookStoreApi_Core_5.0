using System.Linq;
using System;
using WebApiBookStore.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace WebApiBookStore.BookOperations.DeleteBooks
{
    public class DeleteBooksQuery
    {
        private readonly BookContext _bookContext;
        public int BookId { get; set; }
        public DeleteBooksQuery(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public void Handle()
        {
            var book = _bookContext.Books.SingleOrDefault(x => x.Id == BookId);
            if (book is null)
            {
                throw new InvalidOperationException("Böyle bir kitap yok");
            }
            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }
    }
}
