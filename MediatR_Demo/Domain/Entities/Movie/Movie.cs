using MediatR_Demo.Core.Enums;

namespace MediatR_Demo.Domain.Entities.Movie
{
    public class Movie
    {
        public Movie(string? title, string? description, MovieGenre? genre, int? rating)
        {
            Title = title;
            Description = description;
            Genre = genre;
            Rating = rating;
        }

        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public MovieGenre? Genre { get; set; }
        public int? Rating { get; set; }
    }
}