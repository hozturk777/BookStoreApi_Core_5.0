using AutoMapper;
using WebApiBookStore.Entities;
using static WebApiBookStore.Application.BookOperations.Commands.CreateBooks.CreateBooksQuery;
using static WebApiBookStore.Application.BookOperations.Quaries.GetBooks.GetBooksQuery;
using static WebApiBookStore.Application.BookOperations.Commands.UpdateBooks.UpdateBooksQuery;
using WebApiBookStore.Application.BookOperations.Quaries.GetBookDetails;
using static WebApiBookStore.Application.GenreOperations.Quaries.GetGenre.GetGenresQuery;
using WebApiBookStore.Application.GenreOperations.Commands.CreateGenres;
using static WebApiBookStore.Application.GenreOperations.Commands.CreateGenres.CreateGenresCommand;
using static WebApiBookStore.Application.GenreOperations.Quaries.GetGenreDetails.GetGenreDetailQuery;

namespace WebApiBookStore.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreDetailModel>();
            CreateMap<CreateGenreModel, Genre>();
        }
    }
}
