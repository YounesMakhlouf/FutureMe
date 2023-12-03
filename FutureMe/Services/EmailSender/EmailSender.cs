using System.Net;
using System.Net.Mail;
namespace FutureMe.Services.EmailSender
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("storyverse19@gmail.com", "vkhaqwwyhdjkpeyn")
        };
            return client.SendMailAsync(
           new MailMessage(from: "storyverse19@gmail.com",
                           to: email,
                           subject,
                           message
                           ));
        }
    }
}
