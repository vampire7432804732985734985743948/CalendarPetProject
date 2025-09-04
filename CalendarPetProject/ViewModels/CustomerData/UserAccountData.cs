using CalendarPetProject.Models;
using CalendarPetProject.Models.CustomerData;

namespace CalendarPetProject.ViewModels.CustomerData
{
    public class UserAccountData
    {
        public CustomerBodyParametersModel? CustomerBodyParameters { get; private set; } 
        public Users UserPrivateData { get; private set; }
        public UserProfileDataModel? UserProfileData { get; set; }
        public UserAccountData(Users users, CustomerBodyParametersModel customerBodyParametersModel, UserProfileDataModel userProfileData) 
        { 
            UserPrivateData = users; 
            CustomerBodyParameters = customerBodyParametersModel;
            UserProfileData = userProfileData;
        }
    }
}
