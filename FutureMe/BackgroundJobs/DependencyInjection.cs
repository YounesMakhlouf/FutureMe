using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FutureMe.BackgroundJobs
{
    public static class DependencyInjection
    {
        public static void AddJobServices(this IServiceCollection services)
        {
             services.AddQuartz(options =>
            {
                var jobKey = JobKey.Create(nameof(EmailSendingBackgroundJob));
                options.UseMicrosoftDependencyInjectionJobFactory();
                options.AddJob<EmailSendingBackgroundJob>(jobKey)
                .AddTrigger(trigger => trigger.ForJob(jobKey)
                .WithSimpleSchedule(schedule => schedule
                    .WithIntervalInSeconds(10)
                    .RepeatForever()));
                });
            services.AddQuartzHostedService();
        }

    }
}
