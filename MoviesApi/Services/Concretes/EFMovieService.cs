using MoviesApi.Entities;
using MoviesApi.Repositories.Abstracts;
using MoviesApi.Services.Abstracts;

namespace MoviesApi.Services.Concretes
{
    public class EFMovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public Task AddAsync(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public Task<List<Movie>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
