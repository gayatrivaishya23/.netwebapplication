using Microsoft.AspNetCore.Mvc;

namespace MovieEventBooking.Controllers
{
    public class HomeController : Controller
    {
        // ✅ Step 1: Default page
        public IActionResult Welcome()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GoToLogin()
        {
            return RedirectToAction("Login", "Account");
        }

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
