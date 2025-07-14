namespace CalendarPetProject.Models
{
    public class CardModel
    {
        public int CardId { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string ImagePath { get; private set; } = string.Empty;

        public CardModel(int cardId, string title, string description, string imagePath)
        {
            CardId = cardId;
            Title = title;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
