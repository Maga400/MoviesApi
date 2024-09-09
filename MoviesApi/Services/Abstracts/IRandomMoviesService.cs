using MoviesApi.Dtos;
using MoviesApi.Entities;

namespace MoviesApi.Services.Abstracts
{
    public interface IRandomMoviesService
    {
        Task<MovieDto> GetRandomMovieAsync();
    }
}
