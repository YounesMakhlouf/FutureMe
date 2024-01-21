using FutureMe.Models;
using FutureMe.Services.EmailSender;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl.AdoJobStore.Common;
using System.Diagnostics.Metrics;

namespace FutureMe.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class EmailSendingBackgroundJob : IJob
    {
        private IEmailSender _sender;
        private AppDbContext _appDbContext;
        private readonly IServiceProvider _provider;

        public EmailSendingBackgroundJob(IEmailSender sender,IServiceProvider provider)
        {
            _sender = sender;
            _provider = provider;
        }
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                using (var scope = _provider.CreateScope())
                {
                    _appDbContext = scope.ServiceProvider.GetService<AppDbContext>();

                    var letters = GetLetters();
                    letters.ForEach(letter =>
                    {
                        _sender.SendEmailAsync(letter.Email, letter.Title, letter.Content);
                    });
                }
            }
            catch (JobExecutionException e)
            {
                throw new JobExecutionException();

            }
            return Task.CompletedTask;
        }
        // Temporary function until we merge other branches
        public List<Letter> GetLetters()
        {
           return _appDbContext.Letters
                .Where(letter => letter.SendingDate.Date == DateTime.Today)
                .ToList();
        }
    }
}
