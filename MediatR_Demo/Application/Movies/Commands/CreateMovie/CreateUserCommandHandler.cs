using MediatR;
using MediatR_Demo.Domain.DTOs.Responses.Movie;
using MediatR_Demo.Repository.Context;

namespace MediatR_Demo.Application.Movies.Commands.CreateMovie
{
    public class CreateUserCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateUserCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreateMovieDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = request.CreateMovie();
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return new CreateMovieDto(movie.Id);
        }
    }
}
