using System.ComponentModel.DataAnnotations;

namespace CalendarPetProject.ViewModels.CustomerData
{
    public class CustomerBodyParametersViewModel
    {
        [Required]
        [Range(0, 300)]
        public int Height { get; set; }

        [Required]
        [Range(0, 500)]
        public int Weight { get; set; }

        [Required]
        public string PhysicalActivityLevel { get; set; } = string.Empty;

        [Required]
        [Range(0, 75)]
        public int FatPercentage { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
