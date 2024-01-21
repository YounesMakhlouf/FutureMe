using Quartz;

namespace FutureMe.BackgroundJobs
{
    public static class UseQuartzExtension
    {
        public static void UseQuartz(this IApplicationBuilder app)
        {
            var scheduler = app.ApplicationServices
                .GetService<BackgroundJobScheduler>();
            scheduler.StartJob();
        }
    }
}
