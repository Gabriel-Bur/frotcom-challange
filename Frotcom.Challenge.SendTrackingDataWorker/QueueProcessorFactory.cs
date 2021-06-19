using Frotcom.Challenge.Queue;

namespace Frotcom.Challenge.SendTrackingDataWorker
{
    public class QueueProcessorFactory : IQueueProcessorFactory
    {
        public IQueueProcessor Create()
        {
            return new ConsoleQueueProcessor();
        }
    }
}