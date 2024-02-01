using FutureMe.Models;
using FutureMe.Repositories;
using FutureMe.Services.EmailSender;
using Quartz;

namespace FutureMe.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class EmailSendingBackgroundJob : IJob
    {
        private readonly IEmailSender _sender;
        private LetterRepository _repository;
        private readonly IServiceProvider _serviceProvider;

        public EmailSendingBackgroundJob(IEmailSender sender, IServiceProvider provider)
        {
            _sender = sender;
            _serviceProvider = provider;
        }
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                SendEmails();
            }
            catch (JobExecutionException e)
            {
                throw new JobExecutionException();
            }
            return Task.CompletedTask;
        }
        public List<Letter> GetLetters()
        {
            return _repository.GetTodaysLetters();
        }

        public void SendEmails()
        {
            using var scope = _serviceProvider.CreateScope();
            _repository = scope.ServiceProvider.GetService<LetterRepository>();
            var letters = GetLetters();
            letters.ForEach(letter =>
            {
                _sender.SendEmailAsync(letter);
            });
        }
    }
}
