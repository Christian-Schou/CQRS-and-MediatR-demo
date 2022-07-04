using MediatR;
using MediatR_Demo.Domain.DTOs.Responses.Movie;

namespace MediatR_Demo.Application.Movies.Queries.GetMovie
{
    public class GetMovieQuery : IRequest<GetMovieDto>
    {
        public GetMovieQuery(long? id)
        {
            Id = id;
        }

        public long? Id { get; set; }
    }
}
