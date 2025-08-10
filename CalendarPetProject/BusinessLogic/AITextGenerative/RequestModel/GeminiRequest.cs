using CalendarPetProject.BusinessLogic.AITextGenerative.RequestModel;

namespace CalendarPetProject.BusinessLogic.AITextGenerative.RequestModel
{
    internal sealed class GeminiRequest
    {
        public required GeminiContent[] Contents { get; set; }
        public required GenerationConfig GenerationConfig { get; set; }
        public required SafetySettings[] SafetySettings { get; set; }
    }
}
