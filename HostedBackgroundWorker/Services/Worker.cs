using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedBackgroundWorker.Services
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private int number = 0;
        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }

        public async Task DOWork(CancellationToken cancellation, string location)
        {
            while (!cancellation.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);
                logger.LogInformation($"Worker ({location}) printing number: {number}");
                await Task.Delay(1000 * 5);
            }
        }
    }
}
