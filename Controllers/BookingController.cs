using Microsoft.AspNetCore.Mvc;
using MovieEventBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieEventBooking.Controllers
{
    public class BookingController : Controller
    {
        private static List<Booking> _bookings = new List<Booking>();
        private static int _nextId = 1;

        [HttpGet]
        public IActionResult BookTicket(string movieTitle)
        {
            ViewBag.MovieTitle = movieTitle;
            return View();
        }

        [HttpPost]
        public IActionResult BookTicket(Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.Id = _nextId++.ToString(); // ✅ FIXED line
                booking.BookingDate = DateTime.Now;
                _bookings.Add(booking);

                TempData["Message"] = "🎉 Booking successful! Proceed to payment.";
                return RedirectToAction("PaymentOptions", "Payment");
            }

            return View(booking);
        }

        public IActionResult MyBookings(string email)
        {
            var userBookings = _bookings
                .Where(b => b.UserEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View(userBookings);
        }
    }
}
