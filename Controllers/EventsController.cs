using Microsoft.AspNetCore.Mvc;
using MovieEventBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieEventBooking.Controllers
{
    public class EventsController : Controller
    {
        private static List<EventModel> Events = new List<EventModel>
        {
            new EventModel {
                EventId = 1,
                Title = "Comic Con 2025",
                Genre = "Pop Culture",
                Duration = "3 Days",
                Year = 2025,
                Price = 800,
                PosterUrl = "/images/comiccon.jpg",
                Description = "A huge pop culture convention with comics, movies, and cosplay.",
                TotalSeats = 20,
                BookedSeats = 3,
                Theaters = new List<string> { "Hall A", "Hall B" },
                Seats = new List<string> { "A1","A2X","A3","A4","B1X","B2","B3","B4","C1","C2","C3","C4" }
            },
            new EventModel {
                EventId = 2,
                Title = "Food Carnival",
                Genre = "Food Festival",
                Duration = "2 Days",
                Year = 2025,
                Price = 500,
                PosterUrl = "/images/foodfest.jpg",
                Description = "A delicious journey for food lovers with street food and gourmet dishes.",
                TotalSeats = 25,
                BookedSeats = 5,
                Theaters = new List<string> { "Food Court 1", "Food Court 2" },
                Seats = new List<string> { "A1","A2","A3X","A4","B1","B2X","B3","B4","C1","C2","C3","C4","D1","D2","D3","D4","E1","E2","E3","E4","F1","F2","F3","F4","F5" }
            },
            new EventModel {
                EventId = 3,
                Title = "Tech Expo 2025",
                Genre = "Technology",
                Duration = "3 Days",
                Year = 2025,
                Price = 1000,
                PosterUrl = "/images/techexpo.jpg",
                Description = "Explore the latest tech innovations, gadgets, and robotics demonstrations.",
                TotalSeats = 30,
                BookedSeats = 10,
                Theaters = new List<string> { "Expo Hall 1", "Expo Hall 2" },
                Seats = new List<string> { "A1","A2X","A3","A4","B1","B2X","B3","B4","C1","C2","C3X","C4","D1","D2","D3","D4","E1","E2","E3","E4","F1","F2","F3","F4","F5","G1","G2","G3","G4","G5","G6" }
            },
            new EventModel {
                EventId = 4,
                Title = "Art & Culture Fair",
                Genre = "Art",
                Duration = "2 Days",
                Year = 2025,
                Price = 600,
                PosterUrl = "/images/artfair.jpg",
                Description = "A celebration of art, handicrafts, and cultural performances.",
                TotalSeats = 15,
                BookedSeats = 5,
                Theaters = new List<string> { "Gallery A", "Gallery B" },
                Seats = new List<string> { "A1","A2X","A3","A4","B1X","B2","B3","B4","C1","C2","C3","C4","D1","D2","D3" }
            },
            new EventModel {
                EventId = 5,
                Title = "Music Fiesta",
                Genre = "Music",
                Duration = "2 Days",
                Year = 2025,
                Price = 950,
                PosterUrl = "/images/musicfiesta.jpg",
                Description = "Live music performances by popular bands and solo artists.",
                TotalSeats = 25,
                BookedSeats = 12,
                Theaters = new List<string> { "Stage 1", "Stage 2" },
                Seats = new List<string> { "A1","A2","A3X","A4","B1X","B2","B3","B4","C1","C2","C3X","C4","D1","D2","D3","D4","E1","E2","E3","E4","F1","F2","F3","F4","F5" }
            },
            new EventModel {
                EventId = 6,
                Title = "Startup Summit",
                Genre = "Business/Innovation",
                Duration = "1 Day",
                Year = 2025,
                Price = 1200,
                PosterUrl = "/images/startupsummit.jpg",
                Description = "Network with entrepreneurs, investors, and innovators.",
                TotalSeats = 20,
                BookedSeats = 7,
                Theaters = new List<string> { "Conference Hall A", "Conference Hall B" },
                Seats = new List<string> { "A1","A2X","A3","A4","B1","B2X","B3","B4","C1","C2","C3","C4" }
            },
            new EventModel {
                EventId = 7,
                Title = "Dance Mania",
                Genre = "Dance Show",
                Duration = "1 Day",
                Year = 2025,
                Price = 700,
                PosterUrl = "/images/dance.jpg",
                Description = "An electrifying dance competition with professional dancers.",
                TotalSeats = 18,
                BookedSeats = 8,
                Theaters = new List<string> { "Dance Arena" },
                Seats = new List<string> { "A1","A2X","A3","A4","B1X","B2","B3","B4","C1","C2","C3","C4" }
            },
            new EventModel {
                EventId = 8,
                Title = "Marathon 2025",
                Genre = "Sports",
                Duration = "1 Day",
                Year = 2025,
                Price = 400,
                PosterUrl = "/images/marathon.jpg",
                Description = "Join thousands of runners in this annual city marathon.",
                TotalSeats = 50,
                BookedSeats = 20,
                Theaters = new List<string> { "City Track" },
                Seats = new List<string> { "A1","A2","A3X","A4","B1X","B2","B3","B4","C1","C2","C3","C4","D1","D2","D3","D4","E1","E2","E3","E4","F1","F2","F3","F4","F5","G1","G2","G3","G4","G5","H1","H2","H3","H4","H5","I1","I2","I3","I4","I5","J1","J2","J3","J4","J5","J6" }
            },
            new EventModel {
                EventId = 9,
                Title = "Gaming Fest",
                Genre = "E-Sports",
                Duration = "2 Days",
                Year = 2025,
                Price = 900,
                PosterUrl = "/images/gaming.jpg",
                Description = "Competitive e-sports tournament with popular gaming titles.",
                TotalSeats = 30,
                BookedSeats = 15,
                Theaters = new List<string> { "Gaming Arena" },
                Seats = new List<string> { "A1","A2X","A3","A4","B1","B2X","B3","B4","C1","C2","C3X","C4","D1","D2","D3","D4","E1","E2","E3X","E4","F1","F2","F3","F4","F5","G1","G2","G3","G4","G5","H1","H2","H3","H4","H5" }
            }
        };

        public IActionResult Index()
        {
            return View(Events);
        }

        public IActionResult Details(int id)
        {
            var evt = Events.FirstOrDefault(e => e.EventId == id);
            if (evt == null) return NotFound();

            return View(evt);
        }

        [HttpPost]
        public IActionResult Book(int EventId, string UserName, string Date, string SelectedSeats, string PaymentMethod)
        {
            var evt = Events.FirstOrDefault(e => e.EventId == EventId);
            if (evt == null) return NotFound();

            // Mark selected seats as booked
            var seats = SelectedSeats.Split(',');
            foreach (var seat in seats)
            {
                int index = evt.Seats.FindIndex(s => s.Replace("X", "") == seat.Trim());
                if (index >= 0 && !evt.Seats[index].Contains("X")) evt.Seats[index] += "X";
            }
            evt.BookedSeats += seats.Length;

            TempData["UserName"] = UserName;
            TempData["EventTitle"] = evt.Title;
            TempData["Date"] = Date;
            TempData["SelectedSeats"] = SelectedSeats;
            TempData["PaymentMethod"] = PaymentMethod;
            TempData["TotalAmount"] = seats.Length * evt.Price;

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            ViewBag.UserName = TempData["UserName"];
            ViewBag.EventTitle = TempData["EventTitle"];
            ViewBag.Date = TempData["Date"];
            ViewBag.SelectedSeats = TempData["SelectedSeats"];
            ViewBag.PaymentMethod = TempData["PaymentMethod"];
            ViewBag.TotalAmount = TempData["TotalAmount"];
            return View();
        }
    }
}
