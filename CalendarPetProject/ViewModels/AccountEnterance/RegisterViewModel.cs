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

        [Display(Name = "Remember me?")]

        [Required(ErrorMessage = "Password is reqired")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Write normal password kurwa!!!")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Remember me?")]
        public bool DoesRememberUser { get; set; }

        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

    }
}
