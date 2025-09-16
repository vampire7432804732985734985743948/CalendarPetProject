using CalendarPetProject.Data.Constants;

namespace CalendarPetProject.BusinessLogic.Profile
{
    public class ExperienceLevelHandler
    {
        private readonly Dictionary<int, int> _userProfileLevel = new Dictionary<int, int>()
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

        private int maximumAvailableExperience => _userProfileLevel.Keys.Max();
        private int maxLevel => _userProfileLevel.Values.Max();
        public int ReturnUserProfileLevel(int userExperience)
        {
            int userLevel = 0;
            var userExperienceKeys = _userProfileLevel.Keys.OrderBy(k => k).ToList();

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
        public int ReturnNeededAmmountOfExperience(int userEperience)
        { 
            int currentUerProfileLevel = ReturnUserProfileLevel(userEperience);
            int nextLevelExperienceNeeded = 0;

            if (currentUerProfileLevel == maxLevel)
            {
                return maximumAvailableExperience;
            }
            else
            {
                for (int i = 0; i < _userProfileLevel.Count; i++)
                {
                    if (currentUerProfileLevel == _userProfileLevel.Values.ElementAt(i))
                    {
                        nextLevelExperienceNeeded = _userProfileLevel.Keys.ElementAt(i + 1);
                        break;
                    }
                }
            }

            return nextLevelExperienceNeeded;
        }
    }
}
