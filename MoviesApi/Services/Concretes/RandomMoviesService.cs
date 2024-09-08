using Microsoft.AspNetCore.Mvc;
using MoviesApi.Entities;
using MoviesApi.Services.Abstracts;
using Newtonsoft.Json.Linq;
using System.IO;

namespace MoviesApi.Services.Concretes
{
    public class RandomMoviesService : IRandomMoviesService
    {
        private readonly HttpClient _httpClient;
        private readonly IMovieService _movieService;

        public RandomMoviesService(HttpClient httpClient, IMovieService movieService)
        {
            _httpClient = httpClient;
            _movieService = movieService;
        }

        public async Task GetMoviesByRandomLetter()
        {
            // Rastgele harf seçimi
            var letters = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            char randomLetter = letters[random.Next(letters.Length)];

            // OMDb API anahtarını buraya ekle
            var apiKey = "a581e938";

            // OMDb API'ye istek at
            var response = await _httpClient.GetAsync($"http://www.omdbapi.com/?apikey={apiKey}&s={randomLetter}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var movies = JObject.Parse(content);

                var moviesList = new List<Movie>();

                if (movies["Search"] != null)
                {
                    foreach (var movie in movies["Search"])
                    {
                        var movieItem = new Movie
                        {
                            Title = movie["Title"]?.ToString(),
                            Year = (int)(movie["Year"]),
                            Type = movie["Type"]?.ToString(),
                            Actors = movie["Actors"]?.ToString(),
                            imdbID = (int)(movie["imdbID"]),
                        };

                        moviesList.Add(movieItem);
                    }
                }
                var addedMovie = moviesList.FirstOrDefault();
                await _movieService.AddAsync(addedMovie);

                //return Ok(movies);
            }

            //return BadRequest("Movies could not be fetched.");
        }
    }
}
