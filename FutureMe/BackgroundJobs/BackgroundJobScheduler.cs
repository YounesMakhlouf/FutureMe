using FutureMe.Services.EmailSender;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace FutureMe.BackgroundJobs
{
    public class BackgroundJobScheduler 
    {
        private IJobFactory _jobFactory;
            public BackgroundJobScheduler(IJobFactory jobFactory) 
        {
           
            _jobFactory = jobFactory;

        }

        public  async void StartJob()
        {
            var scheduler= await StdSchedulerFactory.GetDefaultScheduler();
            scheduler.JobFactory =_jobFactory;

            var job = JobBuilder.Create<EmailSendingBackgroundJob>()
                .WithIdentity(typeof(EmailSendingBackgroundJob).Name)
                .Build();
   
            var trigger = TriggerBuilder.Create()
                .WithIdentity("trigger","group")
                .StartNow()
                .WithSimpleSchedule(schedule => schedule
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            await scheduler.Start();

            await scheduler.ScheduleJob(job,trigger);



        }
    }
}
