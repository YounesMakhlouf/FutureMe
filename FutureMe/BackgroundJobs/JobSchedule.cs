namespace FutureMe.BackgroundJobs
{
    public class JobSchedule
    {
        public JobSchedule(Type jobType)
        {
            JobType = jobType;
        }

        public Type JobType { get; }

    }
}
