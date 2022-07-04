using MediatR_Demo.Domain.DTOs.Responses.Movie;
using MediatR_Demo.Domain.Entities.Movie;

namespace MediatR_Demo.Application.Movies.Queries.GetMovie
{
    public static class GetMovieQueryExtensions
    {
        public static GetMovieDto MapTo(this Movie movie)
        {
            return new GetMovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                Genre = movie.Genre,
                Rating = movie.Rating
            };
        }
    }
}
