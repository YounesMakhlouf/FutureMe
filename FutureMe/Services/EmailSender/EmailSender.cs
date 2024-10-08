using FutureMe.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace FutureMe.Services.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IConfiguration configuration, ILogger<EmailSender> logger)
        {
            _emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
            _logger = logger;
        }


        public async Task SendEmailAsync(Letter letter)
        {
            try
            {
                var emailMessage = CreateEmailMessage(letter);

                using var smtpClient = new SmtpClient();
                await smtpClient.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, SecureSocketOptions.StartTls).ConfigureAwait(false);
                await smtpClient.AuthenticateAsync(_emailSettings.UserName, _emailSettings.Password).ConfigureAwait(false);
                await smtpClient.SendAsync(emailMessage).ConfigureAwait(false);
                await smtpClient.DisconnectAsync(true).ConfigureAwait(false);

                _logger.LogInformation("Email sent successfully to {Email}", letter.Email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending email to {Email}", letter.Email);
                throw;
            }
        }

        private MimeMessage CreateEmailMessage(Letter letter)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("FutureMe", _emailSettings.UserName));
            emailMessage.To.Add(new MailboxAddress("", letter.Email));
            emailMessage.Subject = letter.Title;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = $@"
Dear Time Traveler,

Greetings from your past self!

On {letter.WritingDate.ToString("D")}, you wrote a letter filled with thoughts, hopes, and reflections. Today, it's time to revisit those words and see how far you've come.

---

{letter.Content}

---

Cherish these memories, and keep moving forward!

Warm regards,
Your Past Self
"
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            return emailMessage;
        }
    }
}