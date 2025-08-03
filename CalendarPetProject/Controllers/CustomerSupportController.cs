using CalendarPetProject.Data;
using CalendarPetProject.Models;
using CalendarPetProject.Models.CustomerSupport;
using CalendarPetProject.ViewModels.Contact;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CalendarPetProject.Controllers
{
    public class CustomerSupportController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CustomerSupportController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public IActionResult ContactSupport()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactSupport(ContactSupportViewModel contactSupportViewModel)
        {
            if (!ModelState.IsValid) 
            { 
                return View(contactSupportViewModel);
            }

            var contactSupportForm = new ContactSupportModel
            {
                RequestTitle = contactSupportViewModel.RequestTitle,
                UserEmailAddress = contactSupportViewModel.UserEmailAddress,
                RequestDescription = contactSupportViewModel.RequestDescription,
                Category = contactSupportViewModel.Category,
                RequestStatus = "Opened",
                CaseSubmitionTime = DateTime.Now,
            };
            _appDbContext.ContactSupportCases.Add(contactSupportForm);
            _appDbContext.SaveChanges();
            
            return View("ThanksForSupportRequest");
        }
    }
}
