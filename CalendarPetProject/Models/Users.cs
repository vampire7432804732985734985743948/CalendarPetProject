using Microsoft.AspNetCore.Identity;

namespace CalendarPetProject.Models
{
    public class Users : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
