using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Entities;
using MoviesApi.Repositories.Abstracts;

namespace MoviesApi.Repositories.Concretes
{
    public class EFMovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;
        public async Task AddAsync(Movie movie)
        {
            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
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
