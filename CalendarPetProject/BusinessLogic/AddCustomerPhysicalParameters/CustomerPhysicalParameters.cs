using CalendarPetProject.ViewModels.CustomerData;

namespace CalendarPetProject.BusinessLogic.AddCustomerPhysicalParameters
{
    public class CustomerPhysicalParameters
    {
        private readonly Dictionary<string, double> _physicalActivityLevel = new Dictionary<string, double>()
        {
            { PhysicalActivities.Sitting, 1.2 },
            { PhysicalActivities.LightlyActive, 1.375 },
            { PhysicalActivities.ModeratelyActive, 1.55 },
            { PhysicalActivities.VeryActive, 1.725 },
            { PhysicalActivities.ExtraActive, 1.9 }
        };
        private readonly CustomerBodyParametersViewModel _customerBodyParameters;

        public CustomerPhysicalParameters(CustomerBodyParametersViewModel customerBodyParameters)
        {
            _customerBodyParameters = customerBodyParameters;
        }

        public double GetAclivityCoefficient() => _physicalActivityLevel[_customerBodyParameters.PhysicalActivityLevel];
        public int CalculateTDEE()
        {
            double physicalActivityCoeficient = GetAclivityCoefficient();
            return Convert.ToInt32(CalculateBMR() * physicalActivityCoeficient);
        }
        public int CalculateBMR()
        {
            const int MINIMAL_BODY_LIFE_SUPPORT_EXPENDITURE = 370;
            const double ENERGY_COMSUMPTION_COEFFICIENT = 21.6;
            double muscleWeight = CalculateFFM();

            return Convert.ToInt32(MINIMAL_BODY_LIFE_SUPPORT_EXPENDITURE + (muscleWeight * ENERGY_COMSUMPTION_COEFFICIENT));
        }
        public double CalculateFFM() => _customerBodyParameters.Weight * (1 - (_customerBodyParameters.FatPercentage / 100));
    }
}
