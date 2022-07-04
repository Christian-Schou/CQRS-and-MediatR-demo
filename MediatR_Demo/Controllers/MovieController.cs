using MediatR;
using MediatR_Demo.Application.Movies.Commands.CreateMovie;
using MediatR_Demo.Application.Movies.Queries.GetMovie;
using MediatR_Demo.Application.Movies.Queries.GetMovies;
using MediatR_Demo.Domain.DTOs.Requests.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediatR_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            var movies = await _mediator.Send(new GetMoviesQuery());

            if (movies != null)
            {
                return Ok(movies);
            }

            return NotFound("No movies in database. Please add a movie first.");
        }

        [HttpGet("/getmovies/{id}")]
        public async Task<IActionResult> GetMovie(long id)
        {
            var movie = await _mediator.Send(new GetMovieQuery(id));

            if (movie != null)
            {
                return Ok(movie);
            }

            return NotFound($"No movie in database with ID: {id}.");

        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieRequest request)
        {
            var movie = await _mediator.Send(new CreateMovieCommand(
                request.Title,
                request.Description,
                request.Genre,
                request.Rating));

            return Ok(movie);
        }
    }
}
