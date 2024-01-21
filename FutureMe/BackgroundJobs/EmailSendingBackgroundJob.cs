using FutureMe.Models;
using FutureMe.Services.EmailSender;
using Quartz;
using System.Diagnostics.Metrics;

namespace FutureMe.BackgroundJobs
{
    public class EmailSendingBackgroundJob : IJob
    {
        //private IEmailSender _sender;
        //public  EmailSendingBackgroundJob(EmailSender sender)
        //{
        //    _sender = sender;
        //}
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("test");
            //var letters = GetLetters();
            //letters.ForEach(letter =>
            //{
            //   _sender.SendEmailAsync(letter.Email, letter.Title, letter.Content);
            //});
            //_sender.SendEmailAsync("salmabouabidi019@gmail.com","test", "test");
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
