using Microsoft.AspNetCore.Mvc;
using MovieEventBooking.Models;
using MovieEventBooking.Services;
using MongoDB.Driver;

namespace MovieEventBooking.Controllers
{
    public class AccountController : Controller
    {
        private readonly MongoService _mongo;

        public AccountController(MongoService mongo)
        {
            _mongo = mongo;
        }

        public IActionResult Welcome() => View();
        public IActionResult Register() => View();
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Register(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ViewBag.Error = "❌ Please fill all fields.";
                return View();
            }

            var existing = _mongo.Users.Find(u => u.Email == email).FirstOrDefault();
            if (existing != null)
            {
                ViewBag.Error = "⚠️ Email already registered.";
                return View();
            }

            _mongo.Users.InsertOne(new User { Email = email, Password = password });
            TempData["Message"] = "✅ Registration successful! Please login now.";
            return RedirectToAction("Login");
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _mongo.Users.Find(u => u.Email == email && u.Password == password).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Error = "❌ Invalid Email or Password!";
                return View();
            }

            HttpContext.Session.SetString("UserEmail", email);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Welcome", "Home");
        }
    }
}
