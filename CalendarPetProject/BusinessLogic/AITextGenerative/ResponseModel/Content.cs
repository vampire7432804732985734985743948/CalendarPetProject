namespace CalendarPetProject.BusinessLogic.AITextGenerative.ResponseModel
{
    internal sealed class Content
    {
        public required Part[] Parts { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
