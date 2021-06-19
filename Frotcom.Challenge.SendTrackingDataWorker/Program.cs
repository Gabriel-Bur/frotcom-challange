using Frotcom.Challenge.Queue;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Frotcom.Challenge.SendTrackingDataWorker
{
    class Program
    {
        /// <summary>
        /// FROTCOM CHALLENGE STARTS HERE
        /// </summary>
        public static async Task Main()
        {
            await Host.CreateDefaultBuilder()
                .ConfigureServices((hostBuilderContext, serviceCollection) => 
                {
                    serviceCollection.AddHostedService<BackgroundHostedService>();

                    serviceCollection.AddScoped<IQueueProcessorFactory, QueueProcessorFactory>();
                })
                .RunConsoleAsync();
        }
    }
}
