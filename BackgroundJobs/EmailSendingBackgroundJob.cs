using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FutureMe.Services.EmailSender;
namespace BackgroundJobs
{
    private readonly IEmailSender emailSender;
     class EmailSendingBackgroundJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
