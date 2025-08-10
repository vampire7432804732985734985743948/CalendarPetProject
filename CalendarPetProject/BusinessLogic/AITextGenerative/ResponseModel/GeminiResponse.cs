namespace CalendarPetProject.BusinessLogic.AITextGenerative.ResponseModel
{
    internal sealed class GeminiResponse
    {
        public required Candidate[] Candidates { get; set; }
        public required PromptFeedback PromptFeedback { get; set; }
    }
}
