using FutureMe.Models;
using System.Net;
using System.Net.Mail;
namespace FutureMe.Services.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Task SendEmailAsync(Letter letter)
        {
            string smtpServer = _configuration["EmailSettings:SmtpServer"];
            int smtpPort = _configuration.GetValue<int>("EmailSettings:SmtpPort");
            string userName = _configuration["EmailSettings:UserName"];
            string password = _configuration["EmailSettings:Password"];


            var client = new SmtpClient(smtpServer, smtpPort)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(userName, password)
            };

           var content = $"A message, carefully penned on {letter.WritingDate.Date}, has embarked on a journey through time. Today, it arrives, carrying words from your yesterdays.\n{letter.Content}";
           return client.SendMailAsync(
           new MailMessage(from: userName,
                           to: letter.Email,
                           letter.Title,
                           content
                           ));
        }
    }
}
