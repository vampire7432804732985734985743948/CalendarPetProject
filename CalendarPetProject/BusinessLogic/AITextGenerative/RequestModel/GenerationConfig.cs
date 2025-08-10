namespace CalendarPetProject.BusinessLogic.AITextGenerative.RequestModel
{
    internal sealed class GenerationConfig
    {
        public int Temperature { get; set; }
        public int TopK { get; set; }
        public int TopP { get; set; }
        public int MaxOutputTokens { get; set; }
        public required List<object> StopSequences { get; set; }
    }
}
