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
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder()
                .ConfigureServices((hostBuilderContext, serviceCollection) =>
                {
                    serviceCollection.AddHostedService<BackgroundHostedService>();
                    serviceCollection.AddScoped<IQueueProcessorFactory, QueueProcessorFactory>();
                    serviceCollection.AddSingleton<PacketCounterSingleton>();
                });
        }
    }
}
