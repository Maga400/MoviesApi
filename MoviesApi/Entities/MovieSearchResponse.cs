using MoviesApi.Dtos;
using Newtonsoft.Json;

namespace MoviesApi.Entities
{
    public class MovieSearchResponse
    {
        //[JsonProperty("Search")]
        public List<MovieDto> Search { get; set; }

    }
}
