using System.ComponentModel.DataAnnotations;

namespace CalendarPetProject.ViewModels.AccountEnterance
{
    public class EmailContainerViewModel
    {
        [Display(Name = "Work email")]
        [Required(ErrorMessage = "Email is reqired")]
        public string Email { get; set; } = string.Empty;
    }
}
