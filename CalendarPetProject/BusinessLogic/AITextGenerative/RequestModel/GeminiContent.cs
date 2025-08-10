namespace CalendarPetProject.BusinessLogic.AITextGenerative.RequestModel
{
    internal sealed class GeminiContent
    {
        public string Role { get; set; } = string.Empty;
        public required GeminiPart[] Parts { get; set; }
    }
}
