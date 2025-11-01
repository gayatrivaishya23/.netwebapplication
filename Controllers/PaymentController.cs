using Microsoft.AspNetCore.Mvc;

namespace MovieEventBooking.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult PaymentOptions()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessPayment(string method)
        {
            ViewBag.Method = method;
            return RedirectToAction("PaymentSuccess");
        }

        public IActionResult PaymentSuccess()
        {
            return View();
        }
    }
}
