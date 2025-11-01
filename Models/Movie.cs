using System.Collections.Generic;

namespace MovieEventBooking.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public List<string> Theaters { get; set; }
        public List<string> Seats { get; set; }
    }
}
