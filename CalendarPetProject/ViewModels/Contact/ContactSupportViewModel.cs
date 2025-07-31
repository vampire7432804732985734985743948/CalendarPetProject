using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace CalendarPetProject.ViewModels.Contact
{
    public class ContactSupportViewModel
    {
        public ContactSupportViewModel()
        {
                
        }
        [Required(ErrorMessage = "Email is reqired")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string UserEmailAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title is reqired")]
        [Display(Name = "Title")]
        public string RequestTitle { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string RequestDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is reqired")]
        [Display(Name = "Choose a problem category:")]
        public string Category { get; set; } = string.Empty;



    }
}
