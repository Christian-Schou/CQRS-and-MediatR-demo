using MediatR;
using MediatR_Demo.Domain.DTOs.Responses.Movie;
using MediatR_Demo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediatR_Demo.Application.Movies.Queries.GetMovies
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IList<GetMovieDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetMoviesQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<GetMovieDto>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = await _dbContext.Movies.ToListAsync();
            var movieList = new List<GetMovieDto>();
            foreach (var movieItem in movies)
            {
                var movie = movieItem.MapTo();
                movieList.Add(movie);
            }

            return movieList;
        }
    }
}
