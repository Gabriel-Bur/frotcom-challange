using Frotcom.Challenge.Queue;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Frotcom.Challenge.SendTrackingDataWorker
{
    public class BackgroundHostedService : IHostedService
    {
        private readonly IQueueProcessorFactory _processorFacotry;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private QueueProcessorHost _processorHost;

        public BackgroundHostedService(
            IQueueProcessorFactory processorFactory, 
            IHostApplicationLifetime applicationLifetime)
        {
            _processorFacotry = processorFactory;
            _applicationLifetime = applicationLifetime;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _applicationLifetime.ApplicationStarted.Register(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    if (_processorHost == null)
                    {
                        _processorHost = new QueueProcessorHost(_processorFacotry, 10, 100);
                        await _processorHost.Run();
                    }
                }
            });

            _applicationLifetime.ApplicationStopped.Register(() =>
            {
                Console.WriteLine("Stopping service");
                _processorHost.Stop();
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
