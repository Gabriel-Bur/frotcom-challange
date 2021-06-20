using System;

namespace Frotcom.Challenge.SendTrackingDataWorker
{
    public sealed class PacketCounterSingleton
    {
        private static readonly PacketCounterSingleton instance = new PacketCounterSingleton();
        public static PacketCounterSingleton Instance
        {
            get 
            {
                return instance;
            }
        }

        internal Int64 Total;
        internal Int64 TotalInPortugal;

        static PacketCounterSingleton() { }
        private PacketCounterSingleton() { }
    }
}
