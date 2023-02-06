using System;
using System.Linq;
using System.Reflection.Metadata;
using WebApi;
using WebApiBookStore.Common;
using WebApiBookStore.DbOperations;

namespace WebApiBookStore.BookOperations.GetBookDetails
{
    public class GetBookDetailQuery
    {
        private readonly BookContext _bookContext;
        public int BookId { get; set; }

        public GetBookDetailQuery(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public BookDetailViewModel Handle()
        {
            var GetBook = _bookContext.Books.Where(x => x.Id == BookId).SingleOrDefault();
            if (GetBook is null)
            {
                throw new InvalidOperationException("Bulunamadı");
            }
            BookDetailViewModel vm = new BookDetailViewModel();
            vm.Title = GetBook.Title;
            vm.PageCount = GetBook.PageCount;
            vm.PublishDate = GetBook.PublishDate.Date.ToString("dd/mm/yyy");
            vm.Genre = ((GenreEnum)GetBook.GenreId).ToString();
            return vm;
        }
          
    }
    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}
