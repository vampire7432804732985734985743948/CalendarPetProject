using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalendarPetProject.Models.CustomerData
{
    public class CustomerBodyParametersModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public Users User { get; set; } = null!;
        public int Height { get; set; }
        public double Weight { get; set; }
        public int FatPercentage { get; set; }
        public string PhysicalActivityLevel { get; set; } = string.Empty;
        public double ActivityCoefficient { get; set; }
        public double FFM { get; set; }
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public int Age { get; set; }
    }
}
