using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarPetProject.BusinessLogic.Security.Password;
using FluentAssertions;

namespace PerProjectTest
{
    public class PasswordGeneratorTests
    {
        [Fact]

        public void GeneratePassworTest()
        {
            int PASSWORD_LENGTH = 20;
            string generatedPassword = new PasswordGenerator().GeneratePassword(PASSWORD_LENGTH);
            generatedPassword.Length.Should().Be(PASSWORD_LENGTH);
            
        }
    }
}
