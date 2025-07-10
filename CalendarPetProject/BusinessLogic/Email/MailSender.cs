using System.Net;
using System.Net.Mail;
using CalendarPetProject.Data.Constants;


namespace CalendarPetProject.BusinessLogic.Email
{
    public class MailSender
    {
        public void SendEmailMessage(string recipientEmail, string subject, string description)
        {
            if (string.IsNullOrWhiteSpace(recipientEmail) || string.IsNullOrWhiteSpace(subject) || string.IsNullOrWhiteSpace(description))
            {
                return;
            }
            MailMessage message = new MailMessage();
            message.From = new MailAddress(EmailAddressConstantsCollector.CompanyPublicEmailAddress);
            message.To.Add(recipientEmail);
            message.Subject = subject;
            message.Body = description;
            message.IsBodyHtml = false; //need to be changed


        }
    }
}
