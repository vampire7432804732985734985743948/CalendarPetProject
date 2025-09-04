using CalendarPetProject.Models;
using CalendarPetProject.Models.CustomerData;
using CalendarPetProject.Models.CustomerSupport;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalendarPetProject.Data
{
    public class AppDbContext : IdentityDbContext<Users>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected AppDbContext()
        {
        }
        public DbSet<Users> UsersSet { get; set; }
        public DbSet<ContactSupportModel> ContactSupportCases { get; set; }
        public DbSet<CustomerBodyParametersModel> CustomerBodyParameters { get; set; }
        public DbSet<UserProfileDataModel> UserProfileData { get; set; }
    }
}
