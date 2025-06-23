using CalendarPetProject.BusinessLogic.Security.Password;
using CalendarPetProject.Models;
using CalendarPetProject.ViewModels.AccountEnterance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CalendarPetProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;

        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                Users users = new Users()
                {
                    FirstName = registerViewModel.FirstName,
                    SecondName = registerViewModel.LastName,
                    Email = registerViewModel.Login,
                    PasswordHash = PasswordHasher.HashPassword(registerViewModel.Password),
                    DateOfBirth = registerViewModel.DateOfBirth
                };
                var result = await _userManager.CreateAsync(users, registerViewModel.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError("Error:", error.Description);
                    }
                    return View(registerViewModel);
                }
            }
            return View(registerViewModel);
        }
    }
    
}
