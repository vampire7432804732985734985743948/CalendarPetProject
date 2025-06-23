using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace CalendarPetProject.Models
{
    public class Users : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }

        public DateOnly DateOfBirth { get; set; }
    }
}
