using MediatR;
using MediatR_Demo.Domain.DTOs.Responses.Movie;
using MediatR_Demo.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace MediatR_Demo.Application.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, GetMovieDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetMovieQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetMovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var movie = await _dbContext.Movies.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (movie != null)
            {
                var movieItem = movie.MapTo();
                return movieItem;
            }
            return null;
        }
    }
}