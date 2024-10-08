using Quartz;
using Quartz.Spi;

namespace FutureMe.BackgroundJobs
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider _provider;
        private readonly ILogger<JobFactory> _logger;

        public JobFactory(IServiceProvider provider, ILogger<JobFactory> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return _provider.GetRequiredService(bundle.JobDetail.JobType) as IJob;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating job instance for {JobType}", bundle.JobDetail.JobType.FullName);
                throw new SchedulerException($"Problem while creating job '{bundle.JobDetail.Key}'", ex);
            }
        }

        public void ReturnJob(IJob job)
        {
            if (job is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}