using hangfire.jobs.Jobs;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace hangfire.jobs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;

        public JobController(ILogger<JobController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This job runs once immediately after you trigger it.
        /// Imagine you want to send a welcome email to a new user as soon as they sign up.
        /// A fire-and-forget job can handle sending that email right away without making the user wait.
        /// </summary>
        /// <returns></returns>
        [HttpGet("fireandforget")]
        public IActionResult Index()
        {
            // Enqueue a background job
            BackgroundJob.Enqueue<HangfireSampleJob>(job => job.Run());
            return Ok();
        }

        /// <summary>
        /// This job runs once after a specified delay.
        /// Suppose you want to remind users to complete their profiles 30 minutes after they sign up.
        /// A delayed job can send a reminder email after the 30-minute delay.
        /// </summary>
        /// <returns></returns>
        [HttpGet("delayed")]
        public IActionResult DelayedJob()
        {
            // Enqueue a delayed background job to run after 5 minutes
            BackgroundJob.Schedule<HangfireSampleJob>(job => job.Run(), TimeSpan.FromSeconds(30));
            return Ok();
        }

        /// <summary>
        /// This job runs at regular intervals.
        /// Think of a job that needs to clean up old data from your database every day at midnight.
        /// A recurring job can be set up to run this cleanup task daily without manual intervention.
        /// The recurring job is scheduled in the Program.cs file when the application starts.
        /// </summary>
        /// <returns></returns>
        [HttpGet("recurring")]
        public IActionResult RecurringJob()
        {
            //recurring job is scheduled in program.cs
            return Ok();
        }

        /// <summary>
        /// This job runs only after a specified preceding job has completed.
        /// Consider a scenario where you need to first generate a report and then send it via email.
        /// The first job can handle generating the report, and the continuation job can handle sending the email once the report is ready.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Continuation")]
        public IActionResult ContinuationJob()
        {
            // Enqueue the first job
            var firstJobId = BackgroundJob.Enqueue<FirstJob>(job => job.Run());
            // Enqueue the continuation job
            BackgroundJob.ContinueWith<SecondJob>(firstJobId, job => job.Run());
            return Ok();
        }
    }
}
