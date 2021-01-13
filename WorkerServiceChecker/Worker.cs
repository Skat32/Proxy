using System;
using System.Threading;
using System.Threading.Tasks;
using Logic.Abstracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerServiceChecker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProxyCheckerWorker _worker;
        private readonly int _minutes;

        public Worker(ILogger<Worker> logger, IConfiguration configuration, IProxyCheckerWorker worker)
        {
            _logger = logger;
            _worker = worker;

            _minutes = int.Parse(configuration.GetSection("TimeToRestartInMin").Value);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await _worker.StartWorkerAsync(_minutes);
                
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}