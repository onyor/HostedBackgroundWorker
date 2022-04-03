﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HostedBackgroundWorker.Services
{
    public class DerivedBackgroundPrinter : BackgroundService
    {
        private readonly IWorker worker;

        public DerivedBackgroundPrinter(IWorker worker)
        {
            this.worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await worker.DOWork(stoppingToken, "DerivedBackground");
        }
    }
}
