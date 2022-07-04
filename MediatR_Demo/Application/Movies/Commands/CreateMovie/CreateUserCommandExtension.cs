using MediatR_Demo.Domain.Entities.Movie;

namespace MediatR_Demo.Application.Movies.Commands.CreateMovie
{
    public static class CreateUserCommandExtension
    {
        public static Movie CreateMovie(this CreateMovieCommand command)
        {
            var movie = new Movie
                (
                    command.Title,
                    command.Description,
                    command.Genre,
                    command.Rating
                );

            return movie;
        }
    }
}
