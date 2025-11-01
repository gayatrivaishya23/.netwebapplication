using Microsoft.AspNetCore.Mvc;
using MovieEventBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieEventBooking.Controllers
{
    public class ConcertsController : Controller
    {
        private static List<ConcertModel> Concerts = new List<ConcertModel>
        {
            new ConcertModel {
                ConcertId = 1, Title = "Rock Legends Live", Genre = "Rock", Duration = "2 Hours", Year = 2025,
                Price = 1200, PosterUrl = "/images/rock_legends.jpg", Description = "Legendary rock bands live on stage.",
                TotalSeats = 50, BookedSeats = 10, Theaters = new List<string> { "Concert Hall 1", "Concert Hall 2" },
                Seats = new List<string> { "A1","A2","A3X","A4","B1","B2X","B3","B4","C1","C2","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 2, Title = "Jazz Nights", Genre = "Jazz", Duration = "3 Hours", Year = 2025,
                Price = 1000, PosterUrl = "/images/jazz_nights.jpg", Description = "Smooth jazz evening with world-class musicians.",
                TotalSeats = 40, BookedSeats = 5, Theaters = new List<string> { "Grand Hall 1", "Grand Hall 2" },
                Seats = new List<string> { "A1","A2","A3","A4","B1X","B2","B3","B4","C1","C2","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 3, Title = "Pop Stars Live", Genre = "Pop", Duration = "2.5 Hours", Year = 2025,
                Price = 1500, PosterUrl = "/images/pop_stars.jpg", Description = "Catch your favorite pop stars live.",
                TotalSeats = 60, BookedSeats = 15, Theaters = new List<string> { "Main Stage", "VIP Stage" },
                Seats = new List<string> { "A1","A2","A3","A4","B1","B2X","B3","B4","C1","C2X","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 4, Title = "Classical Evening", Genre = "Classical", Duration = "2 Hours", Year = 2025,
                Price = 900, PosterUrl = "/images/classical_evening.jpg", Description = "Orchestra & classical music performance.",
                TotalSeats = 35, BookedSeats = 3, Theaters = new List<string> { "Concert Hall A", "Concert Hall B" },
                Seats = new List<string> { "A1","A2","A3","A4","B1","B2","B3X","B4","C1","C2","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 5, Title = "EDM Night", Genre = "EDM", Duration = "4 Hours", Year = 2025,
                Price = 1800, PosterUrl = "/images/edm_night.jpg", Description = "Dance all night with EDM beats.",
                TotalSeats = 70, BookedSeats = 20, Theaters = new List<string> { "Dance Arena", "VIP Lounge" },
                Seats = new List<string> { "A1","A2X","A3","A4","B1","B2","B3","B4X","C1","C2","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 6, Title = "Indie Music Fest", Genre = "Indie", Duration = "3 Hours", Year = 2025,
                Price = 1100, PosterUrl = "/images/indie_fest.jpg", Description = "Celebrate indie artists live on stage.",
                TotalSeats = 45, BookedSeats = 8, Theaters = new List<string> { "Indie Stage 1", "Indie Stage 2" },
                Seats = new List<string> { "A1","A2","A3","A4X","B1","B2","B3","B4","C1","C2X","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 7, Title = "Hip Hop Live", Genre = "Hip Hop", Duration = "2 Hours", Year = 2025,
                Price = 1300, PosterUrl = "/images/hiphop_live.jpg", Description = "High-energy hip hop performance.",
                TotalSeats = 50, BookedSeats = 12, Theaters = new List<string> { "Main Stage", "VIP Stage" },
                Seats = new List<string> { "A1X","A2","A3","A4","B1","B2","B3","B4","C1","C2","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 8, Title = "Folk Music Evening", Genre = "Folk", Duration = "2.5 Hours", Year = 2025,
                Price = 800, PosterUrl = "/images/folk_evening.jpg", Description = "Traditional folk music performance.",
                TotalSeats = 40, BookedSeats = 7, Theaters = new List<string> { "Folk Hall 1", "Folk Hall 2" },
                Seats = new List<string> { "A1","A2","A3","A4","B1X","B2","B3","B4","C1","C2","C3","C4" }
            },
            new ConcertModel {
                ConcertId = 9, Title = "Soulful Voices", Genre = "Soul", Duration = "3 Hours", Year = 2025,
                Price = 1200, PosterUrl = "/images/soulful_voices.jpg", Description = "An evening of soulful music.",
                TotalSeats = 45, BookedSeats = 9, Theaters = new List<string> { "Soul Hall 1", "Soul Hall 2" },
                Seats = new List<string> { "A1","A2","A3X","A4","B1","B2","B3","B4","C1","C2","C3","C4" }
            },
            
        };

        public IActionResult Index()
        {
            return View(Concerts);
        }

        public IActionResult Details(int id)
        {
            var concert = Concerts.FirstOrDefault(c => c.ConcertId == id);
            if (concert == null) return NotFound();
            return View(concert);
        }

        [HttpPost]
        public IActionResult Book(int ConcertId, string UserName, string Date, string SelectedSeats, string PaymentMethod)
        {
            var concert = Concerts.FirstOrDefault(c => c.ConcertId == ConcertId);
            if (concert == null) return NotFound();

            var seats = SelectedSeats.Split(',');
            foreach (var seat in seats)
            {
                int index = concert.Seats.FindIndex(s => s.Replace("X", "") == seat.Trim());
                if (index >= 0) concert.Seats[index] += "X";
            }
            concert.BookedSeats += seats.Length;

            TempData["UserName"] = UserName;
            TempData["ConcertTitle"] = concert.Title;
            TempData["Date"] = Date;
            TempData["SelectedSeats"] = SelectedSeats;
            TempData["PaymentMethod"] = PaymentMethod;
            TempData["TotalAmount"] = seats.Length * concert.Price;

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            ViewBag.UserName = TempData["UserName"];
            ViewBag.ConcertTitle = TempData["ConcertTitle"];
            ViewBag.Date = TempData["Date"];
            ViewBag.SelectedSeats = TempData["SelectedSeats"];
            ViewBag.PaymentMethod = TempData["PaymentMethod"];
            ViewBag.TotalAmount = TempData["TotalAmount"];
            return View();
        }
    }
}
