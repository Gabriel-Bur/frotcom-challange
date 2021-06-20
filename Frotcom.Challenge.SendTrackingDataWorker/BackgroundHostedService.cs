using Frotcom.Challenge.Queue;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Frotcom.Challenge.SendTrackingDataWorker
{
    public class BackgroundHostedService : BackgroundService
    {
        private readonly IQueueProcessorFactory _processorFacotry;
        private QueueProcessorHost _processorHost;

        public BackgroundHostedService(
            IQueueProcessorFactory processorFactory)
        {
            _processorFacotry = processorFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_processorHost == null)
                {
                    _processorHost = new QueueProcessorHost(_processorFacotry, 1, 5);
                    await _processorHost.Run();
                }
            }
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stopping process");
            _processorHost.Stop();
            return base.StopAsync(cancellationToken);
        }

    }
}
