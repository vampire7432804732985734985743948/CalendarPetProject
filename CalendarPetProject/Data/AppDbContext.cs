using CalendarPetProject.Models;
using CalendarPetProject.Models.CustomerSupport;
using CalendarPetProject.ViewModels.AccountEnterance;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

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
    }
}
