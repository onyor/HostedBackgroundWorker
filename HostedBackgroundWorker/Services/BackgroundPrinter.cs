using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HostedBackgroundWorker.Services
{
    public class BackgroundPrinter : IHostedService
    {
        private readonly ILogger<BackgroundPrinter> logger;
        private readonly IWorker worker;
      
        public BackgroundPrinter(ILogger<BackgroundPrinter> logger,IWorker worker)
        {
            this.logger = logger;
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //timer = new Timer(o =>
            //{
            //    Interlocked.Increment(ref number);
            //    logger.LogInformation($"Printing from worker {number}");
            //},
            //    null,
            //    TimeSpan.Zero,
            //    TimeSpan.FromSeconds(5));
            //return Task.CompletedTask;

            await worker.DOWork(cancellationToken,"Background");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Printing worker stopping");
            return Task.CompletedTask;
        }
    }
}
