using Frotcom.Challenge.Queue;
using Frotcom.Challenge.SendTrackingDataWorker.BackgroundServices;
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
            await CreateHostBuilder().RunConsoleAsync();
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host
                .CreateDefaultBuilder()
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    serviceCollection.AddHostedService<QueueBackgroundService>();
                    serviceCollection.AddHostedService<TimedBackgroundService>();

                    serviceCollection.AddScoped<IQueueProcessorFactory, QueueProcessorFactory>();
                    serviceCollection.AddSingleton<CounterSingleton>();
                });
        }
    }
}
