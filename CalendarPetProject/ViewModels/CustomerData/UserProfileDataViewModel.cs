using System.ComponentModel.DataAnnotations;

namespace CalendarPetProject.ViewModels.CustomerData
{
    public class UserProfileDataViewModel
    {

        [DataType(DataType.ImageUrl)]
        public IFormFile? ProfileImage { get; set; }
        public byte[]? ProfileImageData { get; set; }
        public string? ConnectedAccountAddresses { get; set; } = string.Empty;
        public string? ProfileDescription { get; set; }
        public string? Country { get; set; } = string.Empty;
        [Display(Name = "Youtube")]
        public string? Youtube { get; set; } = string.Empty;
        [Display(Name = "LinkedIn")]
        public string? LinkedIn { get; set; } = string.Empty;
        [Display(Name = "Instagram")]
        public string? Instagram { get; set; } = string.Empty;
        [Display(Name = "X")]
        public string? X { get; set; } = string.Empty;
        [Display(Name = "Facebook")]
        public string? Facebook { get; set; } = string.Empty;

    }
}
