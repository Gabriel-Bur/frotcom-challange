using Frotcom.Challenge.Data.Models;
using Frotcom.Challenge.Queue;
using Frotcom.Challenge.Reverse.Geocoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Frotcom.Challenge.SendTrackingDataWorker
{
    public class ConsoleQueueProcessor : IQueueProcessor
    {
        private readonly ReverseGeocoding reverseGeocoding = new ReverseGeocoding();

        public Task Process(IEnumerable<Packet> packets, CancellationToken cancellationToken)
        {
            return Task.Run(async () =>
            {
                int packetsCount = packets.Count();

                foreach (var packet in packets)
                {
                    var country = await reverseGeocoding.GetCountry(packet.Latitude, packet.Longitude);

                    if (country == Country.Portugal)
                        PrintPacket(packet.VehicleId, packetsCount);
                }

            }, cancellationToken);
        }

        private void PrintPacket(int vehicleId, int packetsCount)
        {
            var time = DateTime.Now.ToString("MM/dd/yyyy h:mm:ss");
            Console.WriteLine($"{time} Vehicle {vehicleId} send {packetsCount} packets in Portugal");
        }
    }
}
