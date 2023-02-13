using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApiBookStore.Application.GenreOperations.Quaries.GetGenre;
using WebApiBookStore.Application.GenreOperations.Quaries.GetGenreDetails;
using WebApiBookStore.DbOperations;
using static WebApiBookStore.Application.GenreOperations.Quaries.GetGenreDetails.GetGenreDetailQuery;

namespace WebApiBookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {
        private readonly BookContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenresQuery query = new GetGenresQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetIdGenres(int id)
        {
            GenreDetailModel result;

            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper);
            query.ID = id;

            GetGenresDetailValidator validator = new GetGenresDetailValidator();
            validator.ValidateAndThrow(query);

            result = query.Handle();

            return Ok(result);
        }

    }
}
