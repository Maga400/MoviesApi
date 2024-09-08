using MoviesApi.Entities;
using System.IO;

namespace MoviesApi.Services.Concretes
{
    public class RandomMoviesService
    {
        private readonly HttpClient _httpClient;
        private string? Path { get; set; }
        public RandomMoviesService() 
        {
            _httpClient = new HttpClient();
            Path = "http://www.omdbapi.com/t=m";
        }

        public async Task GetRandomMovies()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(Path);
            //if (response.IsSuccessStatusCode)
            //{
            //    var movie = await response.Content.ReadAsAsync<Movie>();
            //}
            //return Movie;
            Console.WriteLine(response.Content);
        }
    }
}
