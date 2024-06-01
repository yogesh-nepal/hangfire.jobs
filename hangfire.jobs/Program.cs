using hangfire.jobs.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
namespace hangfire.jobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // Add Hangfire services
            builder.Services.AddHangfire(config =>
            {
                config.UseMemoryStorage(); // For demo purposes, use in-memory storage
            });
            // Add the processing server as IHostedService
            builder.Services.AddHangfireServer();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            // Use Hangfire Dashboard
            app.UseHangfireDashboard();

            // Schedule a recurring job
            RecurringJob.AddOrUpdate<HangfireSampleJob>(job => job.Run(), Cron.Minutely);

            app.MapControllers();

            app.Run();
        }
    }
}
