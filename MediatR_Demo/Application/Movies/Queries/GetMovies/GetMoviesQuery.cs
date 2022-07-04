using MediatR;
using MediatR_Demo.Domain.DTOs.Responses.Movie;

namespace MediatR_Demo.Application.Movies.Queries.GetMovies
{
    public class GetMoviesQuery : IRequest<IList<GetMovieDto>>
    {
    }
}
