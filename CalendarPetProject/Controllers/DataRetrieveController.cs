using CalendarPetProject.Data;
using CalendarPetProject.Models;
using CalendarPetProject.Models.CustomerData;
using CalendarPetProject.ViewModels.CustomerData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendarPetProject.Controllers
{
    public class DataRetrieveController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;

        public DataRetrieveController(SignInManager<Users> signInManager, UserManager<Users> userManager, AppDbContext appDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _appDbContext.Users.ToListAsync();

            if (users.Count == 0)
                return NotFound("No users found");

            return Ok(users);
        }
        [HttpGet]
        public async Task<IActionResult> PersonalData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var bodyProperties = await _appDbContext.CustomerBodyParameters
                .FirstOrDefaultAsync(b => b.UserId == user.Id);

            var userProfileData = await _appDbContext.UserProfileData
               .FirstOrDefaultAsync(b => b.UserId == user.Id);

            var model = new UserAccountData(user, bodyProperties, userProfileData);
            return View(model);
        }

    }
}