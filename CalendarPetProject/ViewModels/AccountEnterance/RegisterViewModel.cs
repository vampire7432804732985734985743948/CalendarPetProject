using System.ComponentModel.DataAnnotations;

namespace CalendarPetProject.ViewModels.AccountEnterance
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is reqired")]
        [EmailAddress]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Password is reqired")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Write normal password kurwa!!!")]
        [Compare("ConfirmPassword", ErrorMessage = "Password does't match")]
        public string? Password { get; set; }

        [Display(Name = "Corfirm password")]

        [Required(ErrorMessage = "Password is reqired")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Write normal password kurwa!!!")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public DateOnly DateOfBirth { get; set; }


        public RegisterViewModel(string login, string password, string confirmPassword, string firstName, string lastName, DateOnly dateOfBirth)
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
