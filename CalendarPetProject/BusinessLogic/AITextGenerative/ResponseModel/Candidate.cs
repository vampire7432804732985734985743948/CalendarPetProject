namespace CalendarPetProject.BusinessLogic.AITextGenerative.ResponseModel
{
    internal sealed class Candidate
    {
        public required Content Content { get; set; }
        public string FinishReason { get; set; } = string.Empty;
        public int Index { get; set; }
        public required SafetyRating[] SafetyRatings { get; set; }
    }
}
