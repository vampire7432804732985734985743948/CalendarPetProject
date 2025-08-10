using CalendarPetProject.BusinessLogic.AITextGenerative;
using CalendarPetProject.ViewModels.Contact;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace CalendarPetProject.Controllers
{
    public class AITextGenerativeController : Controller
    {
        private readonly GeminiClient _geminiClient;

        public AITextGenerativeController(GeminiClient geminiClient)
        {
            _geminiClient = geminiClient;
        }

        [HttpPost]
        public async Task<IActionResult> GetAIResponse([FromBody] AIContactSupportViewModel aIContactSupportView)
        {
            if (string.IsNullOrWhiteSpace(aIContactSupportView.UserPrompt))
                return View("Index");

            try
            {
                var result = await _geminiClient.GenerateContentAsync(aIContactSupportView.UserPrompt, CancellationToken.None);
                return Json(new {response = result});
            }
            catch (Exception ex)
            {
                return Json(new {response = new StringBuilder($"Sorry, there is an error. Please contact us via customer support form. Error message: {ex}")});
            }
            
        }

        public IActionResult AIContactSupport()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
