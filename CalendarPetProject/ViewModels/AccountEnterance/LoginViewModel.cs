using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CalendarPetProject.ViewModels.AccountEnterance
{
    [Keyless]
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is reqired")]
        [EmailAddress]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Password is reqired")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool DoesRememberUser { get; set; }
    }
}
