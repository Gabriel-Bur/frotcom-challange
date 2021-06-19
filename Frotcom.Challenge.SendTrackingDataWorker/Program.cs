using Frotcom.Challenge.Data.Models;
using Frotcom.Challenge.Queue;
using Frotcom.Challenge.Reverse.Geocoding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

                })
                .RunConsoleAsync();
        }
    }
}
