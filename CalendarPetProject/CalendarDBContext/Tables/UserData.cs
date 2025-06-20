using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalendarPetProject.CalendarDBContext.Tables
{
    [Table("UserData")]
    public class UserData
    {
        
        [Key] public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public UserData() { }
        public UserData(string firstName, string secondName, string login, string password, DateTime dateOfBirth)
        { 
            FirstName = firstName;
            LastName = secondName;
            Login = login;
            Password = password;
            DateOfBirth = dateOfBirth;
        }

        
    }
}
