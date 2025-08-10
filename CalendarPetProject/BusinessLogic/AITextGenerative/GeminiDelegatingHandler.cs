using CalendarPetProject.BusinessLogic.AITextGenerative.RequestModel;
using CalendarPetProject.BusinessLogic.JSONParse;
using CalendarPetProject.Data.Constants;
using CalendarPetProject.Data.Constants.FileNames;
using Microsoft.Extensions.Options;

namespace CalendarPetProject.BusinessLogic.AITextGenerative
{
    internal sealed class GeminiDelegatingHandler : DelegatingHandler
    {
        private ApiKeys _apiKey = JSONSerializer.GetData<ApiKeys>(FileNames.ApiKeyFileName);

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("x-goog-api-key", $"{_apiKey.GeminiApiKey}");

            return base.SendAsync(request, cancellationToken);
        }
    }
}
