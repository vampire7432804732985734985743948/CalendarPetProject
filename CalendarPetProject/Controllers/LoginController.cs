using Microsoft.AspNetCore.Mvc;

namespace CalendarPetProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
