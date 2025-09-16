using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPetProject.Models.CustomerData
{
    public class UserProfileDataModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public byte[]? ProfileImage { get; set; }
        public string? ConnectedAccountAddresses { get; set; } = string.Empty;

        private int _experience;
        public int Experience
        {
            get { return _experience; }
            set
            {
                if (value >= 0)
                {
                    _experience = value;
                }
                else 
                {
                    _experience = 0;
                }
            }
        }

        private int _profileLevel;
        public int ProfileLevel
        {
            get { return _profileLevel; }
            set
            {
                if (value >= 0)
                {
                    _profileLevel = value;
                }
                else
                {
                    _profileLevel = 0;
                }
            }
        }
        public string? ArhivedStreaks { get; set; }
        public string? ProfileDescription { get; set; }
        public string? Country { get; set; } = string.Empty;
        public string? Youtube { get; set; } = string.Empty;
        public string? LinkedIn { get; set; } = string.Empty;
        public string? Instagram { get; set; } = string.Empty;
        public string? X { get; set; } = string.Empty;
        public string? Facebook { get; set; } = string.Empty;

    }
}
