namespace Frotcom.Challenge.SendTrackingDataWorker
{
    public sealed class CounterSingleton
    {
        private static readonly CounterSingleton instance = new CounterSingleton();
        public static CounterSingleton Instance
        {
            get 
            {
                return instance;
            }
        }

        internal int Total;
        internal int TotalInPortugal;

        static CounterSingleton() { }
        private CounterSingleton() { }
    }
}
