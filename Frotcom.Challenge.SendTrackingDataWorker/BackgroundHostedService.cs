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
        public BackgroundHostedService(
            IQueueProcessorFactory processorFactory)
        {
            _processorFacotry = processorFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var processor = new QueueProcessorHost(_processorFacotry, 2, 100);
            await processor.Run();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
