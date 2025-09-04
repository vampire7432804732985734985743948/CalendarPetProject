using CalendarPetProject.Data.Constants;

namespace CalendarPetProject.BusinessLogic.Profile
{
    public class ExperienceLevelHandler
    {
        private Dictionary<int, int> _userProfileLevel = new Dictionary<int, int>()
        {
            { 0, 1 },      
            { 100, 2 },   
            { 300, 3 },    
            { 600, 4 },    
            { 1000, 5 },   
            { 1500, 6 },    
            { 2100, 7 },   
            { 2800, 8 },   
            { 3600, 9 },    
            { 4500, 10 } 
        };

        public int ReturnUserProfileLevel(int userExperience)
        {
            int userLevel = 0;
            var userExperienceKeys = _userProfileLevel.Keys.OrderBy(k => k).ToList();
            int maximumAvailableExperience = _userProfileLevel.Keys.Max();
            int maxLevel = _userProfileLevel[maximumAvailableExperience];

            for (int i = 0; i < userExperienceKeys.Count; i++)
            {
                if (userExperience >= maximumAvailableExperience)
                {
                    return maxLevel;
                }
                if (userExperience >= userExperienceKeys[i] && userExperience < userExperienceKeys[i + 1])
                {
                    if (i == userExperienceKeys.Count - 1 || (userExperience >= userExperienceKeys[i] && userExperience < userExperienceKeys[i + 1]))
                    {
                        userLevel = _userProfileLevel[userExperienceKeys[i]];
                        break;
                    }
                }
            }
            return userLevel;
        }
    }
}
