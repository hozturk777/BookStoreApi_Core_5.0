using AutoMapper;
using WebApi;
using WebApiBookStore.BookOperations.CreateBooks;
using WebApiBookStore.BookOperations.GetBookDetails;
using static WebApiBookStore.BookOperations.CreateBooks.CreateBooksQuery;
using static WebApiBookStore.BookOperations.GetBooks.GetBooksQuery;
using static WebApiBookStore.BookOperations.UpdateBooks.UpdateBooksQuery;

namespace WebApiBookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
        }
    }
}
