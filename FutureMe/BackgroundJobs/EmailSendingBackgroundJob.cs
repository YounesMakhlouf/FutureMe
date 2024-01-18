using FutureMe.Services.EmailSender;
using Quartz;

namespace FutureMe.BackgroundJobs
{
    public class EmailSendingBackgroundJob : IJob
    {
        private readonly EmailSender? _sender;
        public EmailSendingBackgroundJob(EmailSender? sender)
        {
            _sender = sender;
        }
        public Task Execute(IJobExecutionContext context)
        {
            

            return Task.CompletedTask;
        }
    }
}
