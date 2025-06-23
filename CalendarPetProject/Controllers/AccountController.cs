using CalendarPetProject.BusinessLogic.Security.Password;
using CalendarPetProject.CalendarDBContext.DataBaseOperationService;
using CalendarPetProject.Data;
using CalendarPetProject.Models;
using CalendarPetProject.ViewModels.AccountEnterance;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

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

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid && loginViewModel.Login != null && loginViewModel.Password != null)
            {
                var result = await _signInManager.PasswordSignInAsync
                    (
                        loginViewModel.Login,
                        loginViewModel.Password,
                        loginViewModel.DoesRememberUser,
                        lockoutOnFailure: false
                    );
                if (result.Succeeded)
                {
                    return View("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registrationViewModel)
        {
            if (!ModelState.IsValid) return View(registrationViewModel);
            if (string.IsNullOrEmpty(registrationViewModel.Login) || !registrationViewModel.Login.Contains("@gmail.com")) return View(registrationViewModel);

            var user = new Users
            {
                UserName = registrationViewModel.Login,
                Email = registrationViewModel.Login,
                FirstName = registrationViewModel.FirstName,
                SecondName = registrationViewModel.LastName,
                DateOfBirth = registrationViewModel.DateOfBirth
            };

            var result = await _userManager.CreateAsync(user, registrationViewModel.Password);

            if (result.Succeeded)
                return RedirectToAction("Login");

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(registrationViewModel);
        }
    }
    
}
