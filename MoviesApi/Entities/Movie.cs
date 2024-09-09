﻿namespace MoviesApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? ImdbID { get; set; }
        public string? Title { get; set; }
        public int Year {  get; set; }
        public string? Actors { get; set; }
        public string? Type { get; set; }
    }
}
