using CalendarPetProject.BusinessLogic.AddCustomerPhysicalParameters;
using CalendarPetProject.BusinessLogic.Security.Password;
using CalendarPetProject.Data;
using CalendarPetProject.Models;
using CalendarPetProject.Models.CustomerData;
using CalendarPetProject.ViewModels.AccountEnterance;
using CalendarPetProject.ViewModels.CustomerData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CalendarPetProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private const int PASSWORD_LENGTH = 32;

        public AccountController(SignInManager<Users> signInManager, UserManager<Users> userManager, AppDbContext appDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Login);
            if (user == null)
            {
                return View(loginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(
                user.UserName!,
                loginViewModel.Password,
                loginViewModel.DoesRememberUser,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register(string email)
        {
            var model = new RegisterViewModel
            {
                Login = email
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult RedirectToRegister(EmailContainerViewModel emailContainerViewModel)
        {
            if (emailContainerViewModel == null || string.IsNullOrEmpty(emailContainerViewModel.Email))
            {
                return RedirectToAction("GuestView");
            }

            return RedirectToAction("Register", new { email = emailContainerViewModel.Email });
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registrationViewModel, string action)
        {
            if (action == "generatePassword")
            {
                string generatedPassword = new PasswordGenerator().GeneratePassword(PASSWORD_LENGTH);
                ViewBag.GeneratedPassword = generatedPassword;
                registrationViewModel.Password = generatedPassword;
                registrationViewModel.ConfirmPassword = generatedPassword;

                return View(registrationViewModel);
            }

            if (!ModelState.IsValid) return View(registrationViewModel);

            if (string.IsNullOrEmpty(registrationViewModel.Login) || !registrationViewModel.Login.Contains("@gmail.com"))
                return View(registrationViewModel);

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

        [HttpPost]
        public async Task<IActionResult> EditCustomerParameters(CustomerBodyParametersViewModel customerParameters)
        {
            if (!ModelState.IsValid) return View();

            var user = await _userManager.GetUserAsync(User);

            CustomerPhysicalParameters customerPhysicalParameters = new CustomerPhysicalParameters(customerParameters);
            if (user == null)
            {
                return View(customerPhysicalParameters);
            }

            CustomerBodyParametersModel customerBodyParametersModel = new CustomerBodyParametersModel()
            { 
                UserId = user.Id,
                Height = customerParameters.Height,
                Weight = customerParameters.Weight,
                FatPercentage = customerParameters.FatPercentage,
                PhysicalActivityLevel = customerParameters.PhysicalActivityLevel,
                ActivityCoefficient = customerPhysicalParameters.GetAclivityCoefficient(),
                FFM = customerPhysicalParameters.CalculateFFM(),
                BMR = customerPhysicalParameters.CalculateBMR(),
                TDEE = customerPhysicalParameters.CalculateTDEE()
            };

            _appDbContext.CustomerBodyParameters.Add(customerBodyParametersModel);
            _appDbContext.SaveChanges();

            return View("Index", "Home");


        }
    }
    
}
