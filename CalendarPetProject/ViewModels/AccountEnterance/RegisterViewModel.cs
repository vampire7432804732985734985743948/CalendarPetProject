using System.ComponentModel.DataAnnotations;

namespace CalendarPetProject.ViewModels.AccountEnterance
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is reqired")]
        [EmailAddress]
        public string Login { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is reqired")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Write normal password!")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does't match")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Corfirm password")]

        [Required(ErrorMessage = "Password is reqired")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Write normal password!")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }


        public RegisterViewModel(string login, string password, string confirmPassword, string firstName, string lastName, DateTime dateOfBirth)
        {
            Login = login;
            Password = password;
            ConfirmPassword = confirmPassword;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public RegisterViewModel()
        {
                
        }
    }
}
