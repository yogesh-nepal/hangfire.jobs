namespace hangfire.jobs.Jobs
{
    public class SecondJob
    {
        public void Run()
        {
            Console.WriteLine("Continuation job executed!");
        }
    }
}
