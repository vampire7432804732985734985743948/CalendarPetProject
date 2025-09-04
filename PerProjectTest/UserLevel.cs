using CalendarPetProject.BusinessLogic.Profile;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerProjectTest
{
    public class UserLevel
    {
        [Fact]
        public void GetUserProfileLevelTest()
        {
            int experiece = 350;
            ExperienceLevelHandler experienceLevelHandler = new ExperienceLevelHandler();

            int userLevel = experienceLevelHandler.ReturnUserProfileLevel(experiece);

            userLevel.Should().Be(3);
        }
    }
}
