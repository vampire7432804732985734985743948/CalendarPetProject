using System;
using CalendarPetProject.CalendarDBContext.Tables;
using Microsoft.EntityFrameworkCore;

namespace CalendarPetProject.CalendarDBContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserData>().ToTable("UserData");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CalendarDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
        public DbSet<UserData> UsersData { get; set; } = null!;
    }
}
