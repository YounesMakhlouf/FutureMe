using FutureMe.Models;

namespace FutureMe.Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Letter letter);
    }
}
