using Microsoft.AspNetCore.Mvc;
using MoviesApi.Dtos;
using MoviesApi.Entities;
using MoviesApi.Services.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MoviesApi.Services.Concretes
{
    public class RandomMoviesService : IRandomMoviesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _omdbApiKey = "a581e938";
        private readonly Random _random;

        public RandomMoviesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_omdbApiKey = configuration["OmdbApiKey"];
            _random = new Random();
        }

        public async Task<MovieDto> GetRandomMovieAsync()
        {
            // Rastgele bir harf üret (a-z)
            var randomLetter = (char)_random.Next('a', 'z' + 1);
            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?t={randomLetter}&apikey=a581e938");
            response.EnsureSuccessStatusCode();

            //if (response.IsSuccessStatusCode)
            //{
            //    var jsonResponse = await response.Content.ReadAsStringAsync();
            //    var movieResponse = JsonConvert.DeserializeObject<MovieSearchResponse>(jsonResponse);
            //    var movie = movieResponse.Search.First();
            //    return movie;  // İlk filmi döner
            //}

            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var movieResponse = JsonConvert.DeserializeObject<MovieDto>(jsonResponse);
                return movieResponse;  // İlk filmi döner
            }

            return null;
        }
    }
}
