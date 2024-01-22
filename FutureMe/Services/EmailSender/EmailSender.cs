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
        public Task SendEmailAsync(string email, string subject, string message)
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
            return client.SendMailAsync(
           new MailMessage(from: userName,
                           to: email,
                           subject,
                           message
                           ));
        }
    }
}
