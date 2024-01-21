using FutureMe.Models;
using FutureMe.Services.EmailSender;
using Quartz;
using System.Diagnostics.Metrics;

namespace FutureMe.BackgroundJobs
{
    [DisallowConcurrentExecution]
    public class EmailSendingBackgroundJob : IJob
    {
        private IEmailSender _sender;
        public  EmailSendingBackgroundJob(IEmailSender sender)
        {
            _sender = sender;
        }
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Console.WriteLine("test");
                //var letters = GetLetters();
                //letters.ForEach(letter =>
                //{
                //   _sender.SendEmailAsync(letter.Email, letter.Title, letter.Content);
                //});
                _sender.SendEmailAsync("salmabouabidi019@gmail.com","test", "test");
            }
            catch(JobExecutionException e) {
                throw new JobExecutionException();

            }
            return Task.CompletedTask;
        }
        // Temporary function until we merge other branches
        //public List<Letter> GetLetters()
        //{
        //   return _appDbContext.Letters
        //        .Where(letter => letter.SendingDate.Date == DateTime.Today)
        //        .ToList();
        //}
    }
}
