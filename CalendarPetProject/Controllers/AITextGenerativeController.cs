using CalendarPetProject.BusinessLogic.AITextGenerative;
using Microsoft.AspNetCore.Mvc;

namespace CalendarPetProject.Controllers
{
    public class AITextGenerativeController : Controller
    {
        private GeminiClient _geminiClient;

        public AITextGenerativeController(GeminiClient geminiClient)
        {
            _geminiClient = geminiClient;
        }

        [HttpPost]
        public async Task<IActionResult> Ask(string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return View("Index");

            var result = await _geminiClient.GenerateContentAsync(prompt, CancellationToken.None);

            ViewBag.Answer = result;

            return View("Index");
        }
    }
}
