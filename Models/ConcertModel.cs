using System.Collections.Generic;

namespace MovieEventBooking.Models
{
    public class ConcertModel
    {
        public int ConcertId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Duration { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string PosterUrl { get; set; }
        public string Description { get; set; }
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }
        public List<string> Theaters { get; set; }
        public List<string> Seats { get; set; }
    }
}
