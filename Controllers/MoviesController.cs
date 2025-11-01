using Microsoft.AspNetCore.Mvc;
using MovieEventBooking.Models;
using System.Collections.Generic;
using System.Linq;

namespace MovieEventBooking.Controllers
{
    public class MoviesController : Controller
    {
        private static List<Movie> _movies = new();
        private static HashSet<string> _bookedSeats = new();

        public MoviesController()
        {
            if (!_movies.Any())
            {
                _movies = new List<Movie>
                {
                    
                    
                    new Movie {
                        Id = 3, Title = "Interstellar", Genre = "Adventure", Duration = "2h 49m", Year = 2014, Price = 280,
                        Image = "/images/interstellar.jpg",
                        Theaters = new() {
                            "PVR Mumbai - Lower Parel, Mumbai",
                            "Cinepolis Delhi - Rohini, Delhi"
                        },
                        Seats = GenerateSeats()
                    },
                    new Movie {
                        Id = 4, Title = "Dune", Genre = "Sci-Fi", Duration = "2h 35m", Year = 2021, Price = 320,
                        Image = "/images/dune.jpg",
                        Theaters = new() {
                            "INOX Bangalore - Koramangala, Bangalore",
                            "PVR Chennai - Anna Nagar, Chennai"
                        },
                        Seats = GenerateSeats()
                    },
                    new Movie {
                        Id = 5, Title = "Jawan", Genre = "Action", Duration = "2h 50m", Year = 2023, Price = 220,
                        Image = "/images/jawan.jpg",
                        Theaters = new() {
                            "PVR Mumbai - Ghatkopar, Mumbai",
                            "INOX Pune - FC Road, Pune"
                        },
                        Seats = GenerateSeats()
                    },
                    new Movie {
                        Id = 6, Title = "Pathaan", Genre = "Action", Duration = "2h 30m", Year = 2023, Price = 200,
                        Image = "/images/pathaan.jpg",
                        Theaters = new() {
                            "Cinepolis Delhi - Janakpuri, Delhi",
                            "PVR Nagpur - Dharampeth, Nagpur"
                        },
                        Seats = GenerateSeats()
                    },
                    new Movie {
                        Id = 7, Title = "Oppenheimer", Genre = "Drama", Duration = "3h 0m", Year = 2023, Price = 350,
                        Image = "/images/oppenheimer.jpg",
                        Theaters = new() {
                            "INOX Pune - Magarpatta, Pune",
                            "PVR Delhi - Saket, Delhi"
                        },
                        Seats = GenerateSeats()
                    },
                    new Movie {
                        Id = 8, Title = "The Batman", Genre = "Action", Duration = "2h 56m", Year = 2022, Price = 270,
                        Image = "/images/batman.jpg",
                        Theaters = new() {
                            "PVR Mumbai - BKC, Mumbai",
                            "INOX Chennai - T Nagar, Chennai"
                        },
                        Seats = GenerateSeats()
                    },
                    new Movie {
                        Id = 9, Title = "KGF 2", Genre = "Action", Duration = "2h 48m", Year = 2022, Price = 230,
                        Image = "/images/kgf2.jpg",
                        Theaters = new() {
                            "INOX Bangalore - Indiranagar, Bangalore",
                            "PVR Hyderabad - Banjara Hills, Hyderabad"
                        },
                        Seats = GenerateSeats()
                    },
                    new Movie {
                        Id = 10, Title = "Leo", Genre = "Thriller", Duration = "2h 30m", Year = 2023, Price = 240,
                        Image = "/images/leo.jpg",
                        Theaters = new() {
                            "Cinepolis Kochi - MG Road, Kochi",
                            "PVR Chennai - Velachery, Chennai"
                        },
                        Seats = GenerateSeats()
                    }
                };
            }
        }

        private static List<string> GenerateSeats()
        {
            var seats = new List<string>();
            for (char row = 'A'; row <= 'E'; row++)
            {
                for (int col = 1; col <= 8; col++)
                {
                    seats.Add($"{row}{col}");
                }
            }
            return seats;
        }

        public IActionResult Index()
        {
            return View(_movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            if (movie == null) return RedirectToAction("Index");

            ViewBag.BookedSeats = _bookedSeats;
            return View(movie);
        }

        [HttpPost]
        public IActionResult Book(int movieId, string theater, string userEmail, string showDate, string[] seatSelection)
        {
            if (seatSelection == null || seatSelection.Length == 0)
            {
                TempData["Error"] = "Please select at least one seat.";
                return RedirectToAction("Details", new { id = movieId });
            }

            foreach (var seat in seatSelection)
                _bookedSeats.Add(seat);

            TempData["Message"] = $"🎟️ {seatSelection.Length} seat(s) booked successfully at {theater}!";
            return RedirectToAction("Confirmation");
        }
      
        public IActionResult Confirmation()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
    }
}
