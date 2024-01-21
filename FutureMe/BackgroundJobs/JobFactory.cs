using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using System.ComponentModel;

namespace FutureMe.BackgroundJobs
{
    public class JobFactory : SimpleJobFactory
    {
        //provider is an instance of a service provider or dependency injection container.
        IServiceProvider _provider;

        public JobFactory(IServiceProvider provider) {
            _provider = provider;
        }


       public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {

                return (IJob)_provider.GetService(bundle.JobDetail.JobType);
            }
            catch (Exception ex)
            {
                throw new Exception("problem while creating job");
            }
        }
    
    }
}
