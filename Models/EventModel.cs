using System.Collections.Generic;

namespace MovieEventBooking.Models
{
    public class EventModel
    {
        public int EventId { get; set; }           // Unique event ID
        public string Title { get; set; }          // Event title
        public string Description { get; set; }    // Event description
        public string Genre { get; set; }          // Genre/category
        public string Duration { get; set; }       // Duration string
        public int Year { get; set; }              // Event year
        public decimal Price { get; set; }         // Ticket price
        public string PosterUrl { get; set; }      // Image/poster path
        public int TotalSeats { get; set; }        // Total seats
        public int BookedSeats { get; set; }       // Seats already booked

        // Optional: list of seat numbers (if needed for seat selection)
        public List<string> Seats { get; set; } = new List<string>();
        public List<string> Theaters { get; set; } = new List<string>();
    }
}
