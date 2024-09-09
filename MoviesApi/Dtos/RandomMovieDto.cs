using Newtonsoft.Json;

namespace MoviesApi.Dtos
{
    public class RandomMovieDto
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Year")]
        public string Year { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbId { get; set; }

        [JsonProperty("Actors")]
        public string Actor { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }


    }
}
