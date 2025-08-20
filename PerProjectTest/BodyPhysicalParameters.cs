using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarPetProject.BusinessLogic.AddCustomerPhysicalParameters;
using CalendarPetProject.ViewModels.CustomerData;
using Xunit;
using FluentAssertions;


namespace PerProjectTest
{
    public class BodyPhysicalParameters
    {
        private readonly CustomerPhysicalParameters _customerPhysicalParameters = new CustomerPhysicalParameters
        (
            new CustomerBodyParametersViewModel()
            {
                Height = 173,
                Weight = 73,
                FatPercentage = 20,
                PhysicalActivityLevel = PhysicalActivities.LightlyActive,
                Age = 19,
            }
        );
        [Fact]
        public void CalculateFFM()
        {

            double expectedWeigth = 58.4;
            var result = _customerPhysicalParameters.CalculateFFM();

            result.Should().BeApproximately(expectedWeigth, 0.1);

        }
        [Fact]
        public void CalculateBMR()
        {
            int expectedCalories = 1631;
            var result = _customerPhysicalParameters.CalculateBMR();

            result.Should().Be(expectedCalories);
        }
        [Fact]
        public void CalculateTDEE()
        {
            int expectedCalories = 2243;
            var result = _customerPhysicalParameters.CalculateTDEE();

            result.Should().Be(expectedCalories);
        }
    }
}
