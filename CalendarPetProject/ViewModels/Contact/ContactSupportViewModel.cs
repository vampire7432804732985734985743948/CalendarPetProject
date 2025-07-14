using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace CalendarPetProject.ViewModels.Contact
{
    public class ContactSupportViewModel
    {
        public ContactSupportViewModel()
        {
                
        }
        public string UserEmailAddress { get; set; } = string.Empty;
        public string RequestTitle { get; set; } = string.Empty;

        public string RequestDescription { get; set; } = string.Empty;

        public ContactSupportViewModel(string userEmailAddress, string requestTitle, string requestDescription)
        {
            UserEmailAddress = userEmailAddress;
            RequestTitle = requestTitle;
            RequestDescription = requestDescription;
        }
    }
}
