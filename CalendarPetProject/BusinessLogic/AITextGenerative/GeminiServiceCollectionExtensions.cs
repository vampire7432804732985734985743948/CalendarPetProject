using CalendarPetProject.BusinessLogic.AITextGenerative.RequestModel;
using Microsoft.Extensions.Options;

namespace CalendarPetProject.BusinessLogic.AITextGenerative
{
    public static class GeminiServiceCollectionExtensions
    {
        public static void AddGemini(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<GeminiOptions>(configuration.GetSection("Gemini"));

            services.AddTransient<GeminiDelegatingHandler>();

            services.AddHttpClient<GeminiClient>(
                (serviceProvider, httpClient) =>
                {
                    var geminiOptions = serviceProvider
                        .GetRequiredService<IOptions<GeminiOptions>>().Value;

                    httpClient.BaseAddress = new Uri(geminiOptions.Url);
                })
                .AddHttpMessageHandler<GeminiDelegatingHandler>();
        }
    }
}
