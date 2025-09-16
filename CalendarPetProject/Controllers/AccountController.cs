using CalendarPetProject.BusinessLogic.AddCustomerPhysicalParameters;
using CalendarPetProject.BusinessLogic.Security.Password;
using CalendarPetProject.Data;
using CalendarPetProject.Models;
using CalendarPetProject.Models.CustomerData;
using CalendarPetProject.ViewModels.AccountEnterance;
using CalendarPetProject.ViewModels.CustomerData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CalendarPetProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        private const int PASSWORD_LENGTH = 32;
        private bool _wasUserProfileDataFound = false;
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
                DateOfBirth = registrationViewModel.DateOfBirth,
                DateOfAccountCreation = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, registrationViewModel.Password);

            if (result.Succeeded)
            {
                var profileSettings = new UserProfileDataModel
                {
                    UserId = user.Id,
                    ProfileImage = null,
                    Experience = 0,
                    ProfileLevel = 0,
                    ArhivedStreaks = null,
                    ConnectedAccountAddresses = null
                };

                _appDbContext.UserProfileData.Add(profileSettings);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return View(registrationViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCustomerParameters(CustomerBodyParametersViewModel customerParameters)
        {
            if (!ModelState.IsValid)
                return View(customerParameters);
            Console.WriteLine("Post start");
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            CustomerPhysicalParameters customerPhysicalParameters = new CustomerPhysicalParameters(customerParameters);

            var existing = await _appDbContext.CustomerBodyParameters
                .FirstOrDefaultAsync(b => b.UserId == user.Id);

            if (existing != null)
            {
                existing.Age = customerParameters.Age;
                existing.Height = customerParameters.Height;
                existing.Weight = customerParameters.Weight;
                existing.FatPercentage = customerParameters.FatPercentage;
                existing.PhysicalActivityLevel = customerParameters.PhysicalActivityLevel;
                existing.ActivityCoefficient = customerPhysicalParameters.GetAclivityCoefficient();
                existing.FFM = customerPhysicalParameters.CalculateFFM();
                existing.BMR = customerPhysicalParameters.CalculateBMR();
                existing.TDEE = customerPhysicalParameters.CalculateTDEE();
            }
            else
            {
                CustomerBodyParametersModel customerBodyParametersModel = new CustomerBodyParametersModel()
                {
                    UserId = user.Id,
                    Age = customerParameters.Age,
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
            }
            Console.WriteLine("Post end");

            await _appDbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
        private async Task<UserAccountData> GetUser()
        {
            var user = await _userManager.GetUserAsync(User)
                ?? throw new ArgumentException("Cannot find such user");

            var existingBodyParameters = await _appDbContext.CustomerBodyParameters
                .FirstOrDefaultAsync(b => b.UserId == user.Id) ?? new CustomerBodyParametersModel();

            var existingProfileData = await _appDbContext.UserProfileData
                .FirstOrDefaultAsync(b => b.UserId == user.Id) ?? new UserProfileDataModel();

            var existingAccountParameters = await _appDbContext.Users
               .FirstOrDefaultAsync(b => b.Id == user.Id) ?? new Users();

            return new UserAccountData(existingAccountParameters, existingBodyParameters, existingProfileData);
        }
        [HttpGet]
        public async Task<IActionResult> EditCustomerParameters()
        {
            var importedModel = await GetUser();

            var model = new CustomerBodyParametersViewModel();

            if (importedModel != null)
            {
                model.Age = importedModel.CustomerBodyParameters.Age;
                model.Height = importedModel.CustomerBodyParameters.Height;
                model.Weight = importedModel.CustomerBodyParameters.Weight;
                model.FatPercentage = importedModel.CustomerBodyParameters.FatPercentage;
                model.PhysicalActivityLevel = importedModel.CustomerBodyParameters.PhysicalActivityLevel;
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var model = await GetUser();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> UserPage()
        {
            var model = await GetUser();
            return View(model);
        }
        [HttpGet("personal/{id}")]
        public async Task<IActionResult> PersonalData(string id)
        {
            var user = await _appDbContext.Users.FindAsync(id);
            var bodyProperties = await _appDbContext.CustomerBodyParameters
                .FirstOrDefaultAsync(b => b.UserId == id);
            var userProfileData = await _appDbContext.UserProfileData
              .FirstOrDefaultAsync(b => b.UserId == id);

            if (user == null || bodyProperties == null || userProfileData == null)
                return NotFound();

            var model = new UserAccountData(user, bodyProperties, userProfileData);
            return View(model);
        }

        public async Task<IActionResult> UpdateUserProfile()
        {
            var importedModel = await GetUser();
            var model = new UserProfileDataViewModel();
            if (importedModel != null)
            {
                _wasUserProfileDataFound = true;
                model.ProfileImageData = importedModel.UserProfileData.ProfileImage;
                model.ConnectedAccountAddresses = importedModel.UserProfileData.ConnectedAccountAddresses;
                model.ProfileDescription = importedModel.UserProfileData.ProfileDescription;
                model.Country = importedModel.UserProfileData.Country;
                model.Youtube = importedModel.UserProfileData.Youtube;
                model.LinkedIn = importedModel.UserProfileData.LinkedIn;
                model.Instagram = importedModel.UserProfileData.Instagram;
                model.X = importedModel.UserProfileData.X;

            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfileInformation(UserProfileDataViewModel profile)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login");

            var existingProfile = await _appDbContext.UserProfileData
                .FirstOrDefaultAsync(p => p.UserId == user.Id);

            byte[]? imageData = null;


            if (profile.ProfileImage != null && profile.ProfileImage.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await profile.ProfileImage.CopyToAsync(ms);
                    imageData = ms.ToArray();
                }
            }
            if (existingProfile == null)
            {

                UserProfileDataModel newProfile = new UserProfileDataModel
                {
                    UserId = user.Id,
                    ProfileImage = imageData,
                    ConnectedAccountAddresses = profile.ConnectedAccountAddresses,
                    ProfileDescription = profile.ProfileDescription,
                    Country = profile.Country,
                    Youtube = profile.Youtube,
                    LinkedIn = profile.LinkedIn,
                    Instagram = profile.Instagram,
                    X = profile.X,
                };
                _appDbContext.UserProfileData.Add(newProfile);
            }
            else
            {
                existingProfile.ProfileImage = imageData;
                existingProfile.ConnectedAccountAddresses = profile.ConnectedAccountAddresses;
                existingProfile.ProfileDescription = profile.ProfileDescription;
                existingProfile.Country = profile.Country;
                existingProfile.Youtube = profile.Youtube;
                existingProfile.LinkedIn = profile.LinkedIn;
                existingProfile.Instagram = profile.Instagram;
                existingProfile.X = profile.X;
            }

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
       
    }
    
}
