namespace CalendarPetProject.Models
{
    public class CardModel
    {
        public int CardId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}
