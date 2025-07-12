using CalendarPetProject.Models;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace CalendarPetProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return View("LoggedInView");
            }
            else
            {
                ViewBag.ShowDescription = true;
                return View("GuestView");
            }
        }
        [HttpGet]
        public IActionResult GetCardDetails(int id)
        {
            var cards = new List<CardModel>
            {
                new CardModel
                {
                    CardId = 1,
                    Title = "AI Integration",
                    Description = "Integrating AI into a calendar project brings a whole new level of intelligence and convenience to everyday scheduling. Instead of just storing events and reminders, an AI-powered calendar actively helps users manage their time better by learning from habits, analyzing patterns, and making smart suggestions. For instance, it can automatically find the best meeting times based on everyone's availability, suggest rescheduling options when conflicts arise, and even prioritize tasks based on urgency or workload. Natural language processing allows users to quickly add events by typing or speaking in plain English, like \"Call Sarah next Tuesday at 10 AM,\" while smart reminders ensure you never miss a meeting, adjusting based on traffic or travel time. Over time, the calendar becomes more personalized, recommending focus time, detecting overbooking, and even helping users balance work and personal life. It can also integrate with tools like email, task managers, and video conferencing apps, creating a seamless experience across platforms. Whether you're managing a team, juggling client calls, or organizing your personal schedule, AI integration turns your calendar into a helpful assistant that saves time, reduces stress, and",
                    ImagePath = Url.Content("~/Resources/Images/Cards/FullSizeBackground/Ai.jpg")
                },
                new CardModel
                {
                    CardId = 2,
                    Title = "Agjust time by your own",
                    Description = "AI-powered calendars aren’t just about setting reminders—they actually adapt your schedule in real time, adjusting events and tasks automatically based on your behavior, availability, and unexpected changes throughout the day. If a meeting gets canceled or runs long, the AI can rearrange your to-dos without you lifting a finger, keeping your day organized and stress-free. It looks at your past habits, urgency of tasks, and even external factors like weather or traffic to decide what should be moved, shortened, or rescheduled. Instead of you manually dragging events around, the system makes intelligent decisions, like blocking off time for focus if you’ve been stuck in back-to-back meetings or shifting non-essential tasks to tomorrow when your calendar’s full. Over time, it learns how you prefer to work and adjusts accordingly, acting almost like a personal assistant that’s always one step ahead—saving you time, reducing decision fatigue, and helping you make the most of every hour.",
                    ImagePath = Url.Content("~/Resources/Images/Cards/FullSizeBackground/Business.jpg")
                },
                new CardModel
                {
                    CardId = 3,
                    Title = "Plan the best moments in your life",
                    Description = "Beyond managing meetings and tasks, an AI-powered calendar can help you plan the most meaningful parts of your life by intentionally making space for what truly matters. It learns your patterns, preferences, and goals—then suggests the best times for things like vacations, birthdays, date nights, or even quiet time for reflection. Rather than cramming life around work, it gently flips the perspective, reminding you to pause, recharge, and invest in your relationships and personal growth. Whether that means setting aside time to train for a marathon, organize a weekend trip, or simply spend more time with family, the AI finds those windows and adjusts your schedule to fit them in naturally. Over time, it becomes more than just a productivity tool—it becomes a thoughtful companion that encourages a healthier, more fulfilling lifestyle. With smart suggestions and flexible planning, it helps ensure that life’s best moments don’t get lost in the busyness, but instead become a regular, intentional part of your everyday rhythm.",
                    ImagePath = Url.Content("~/Resources/Images/Cards/FullSizeBackground/Plans.jpg")
                },
                new CardModel
                {
                    CardId = 4,
                    Title = "Forget about being late",
                    Description = "With AI handling your calendar, forgetting or being late becomes a thing of the past. Smart reminders don’t just notify you at a fixed time—they adjust based on real-world factors like traffic, location, prep time, and your usual habits. If you have a meeting across town, it might notify you earlier depending on current conditions, or remind you to grab important files before a presentation. Over time, the system learns what kind of reminders work best for you—whether that’s a quiet nudge an hour before, or a persistent alert five minutes out. It also helps prevent last-minute rushes by giving you gentle heads-ups about upcoming tasks or shifts in your day. Instead of having to constantly check the clock or second-guess your timing, you can rely on your calendar to keep you informed and on track. It’s like having a reliable assistant that makes sure you're always one step ahead—calm, prepared, and never scrambling.",
                    ImagePath = Url.Content("~/Resources/Images/Cards/FullSizeBackground/BeNotified.jpg")
                },
                new CardModel
                {
                    CardId = 5,
                    Title = "Be focused on your tasks",
                    Description = "Staying disciplined and focused can be tough in a world full of distractions, but an AI-powered calendar helps bring structure and intention to your day. By analyzing your routines, energy levels, and workload, it can block out time specifically for deep work, limit interruptions, and space out tasks in a way that supports concentration. It learns when you’re most productive and builds a rhythm that keeps you focused without burning out. Instead of bouncing between meetings and to-dos, you get a clear, manageable flow that aligns with your natural pace. The AI can even nudge you when you’re drifting off track or skipping important routines—gently holding you accountable to your own goals. Whether you're working on a long-term project or trying to build better habits, it acts like a silent coach in the background, helping you stay committed, focused, and on top of your priorities every single day.",
                    ImagePath = Url.Content("~/Resources/Images/Cards/FullSizeBackground/Focuse.jpg")
                }
            };

            var card = cards.FirstOrDefault(c => c.CardId == id);
            if (card == null) return NotFound();

            return Json(card);
        }
    }
}
