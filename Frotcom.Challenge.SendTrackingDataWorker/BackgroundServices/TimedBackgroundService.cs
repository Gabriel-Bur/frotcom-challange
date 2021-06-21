using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Frotcom.Challenge.SendTrackingDataWorker.BackgroundServices
{
    public class TimedBackgroundService : BackgroundService
    {
        private Timer _timer;

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var total = CounterSingleton.Instance.Total;
            var inportugal = CounterSingleton.Instance.TotalInPortugal;

            var time = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss");
            Console.WriteLine($"{time} Total: {total}, InPortugal: {inportugal}");
        }
    }
}
