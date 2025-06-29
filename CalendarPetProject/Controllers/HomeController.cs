using System.Diagnostics;
using CalendarPetProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace CalendarPetProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                // User is logged in, return the logged-in view or redirect to a dashboard
                return View("LoggedInView");
            }
            else
            {
                // User is not logged in, return the guest view or redirect to login page
                return View("GuestView");
            }
        }
    }
}
