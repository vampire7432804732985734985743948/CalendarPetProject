using CalendarPetProject.BusinessLogic.AITextGenerative.ResponseModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

namespace CalendarPetProject.BusinessLogic.AITextGenerative
{
    public sealed class GeminiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GeminiClient> _logger;
        private readonly JsonSerializerSettings _serializerSettings = new()
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        public GeminiClient(HttpClient httpClient, ILogger<GeminiClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<string> GenerateContentAsync(string prompt, CancellationToken cancellationToken)
        {
            var requestBody = GeminiRequestFactory.CreateRequest(prompt);
            var content = new StringContent(JsonConvert.SerializeObject(requestBody, Formatting.None, _serializerSettings), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("", content, cancellationToken);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync(cancellationToken);

            var geminiResponse = JsonConvert.DeserializeObject<GeminiResponse>(responseBody);

            var geminiResponseText = geminiResponse?.Candidates[0].Content.Parts[0].Text;
            if (string.IsNullOrWhiteSpace(geminiResponseText))
            {
                return new StringBuilder("Error").ToString();
            }
            else
            {
                return geminiResponseText;
            }
        }
    }
}
