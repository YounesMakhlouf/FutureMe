using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Spi;
using System.ComponentModel;

namespace FutureMe.BackgroundJobs
{
    public class JobFactory :  IJobFactory
    {
        //provider is an instance of a service provider or dependency injection container.
        private readonly IServiceProvider _provider;

        public JobFactory(IServiceProvider provider) {
            _provider = provider;
        }


       public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {

                return _provider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
            }
            catch (Exception ex)
            {
                throw new Exception("problem while creating job");
            }
        }

        public void ReturnJob(IJob job)
        {
        }
    }
}
