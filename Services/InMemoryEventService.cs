using MovieEventBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieEventBooking.Services
{
    public class InMemoryEventService : IEventService
    {
        private readonly List<EventModel> _events = new()
        {
            new EventModel { EventId = 1, Title = "Movie: Avengers", Description = "Superhero Action", PosterUrl = "/images/avengers.jpg", TotalSeats = 100, BookedSeats = 20 },
            new EventModel { EventId = 2, Title = "Concert: Arijit Singh", Description = "Live Music Show", PosterUrl = "/images/concert.jpg", TotalSeats = 200, BookedSeats = 50 },
            new EventModel { EventId = 3, Title = "Comedy Night", Description = "Standup Comedy Show", PosterUrl = "/images/comedy.jpg", TotalSeats = 150, BookedSeats = 30 }
        };

        public List<EventModel> GetAll() => _events;

        public EventModel? GetById(int id) => _events.FirstOrDefault(e => e.EventId == id);
    }
}
