using MicrosoftAzure.Storage.Data.BusinessObjects.Queue;

namespace MicrosoftAzure.Storage.Data.Core.Queue
{
    public class ProcessStorageQueueMessageCore: IProcessStorageQueueMessageCore
    {
        IProcessStorageQueueMessageBO processStorageQueueMessageBO;
        public ProcessStorageQueueMessageCore(IProcessStorageQueueMessageBO _processStorageQueueMessageBO)
        {
            processStorageQueueMessageBO= _processStorageQueueMessageBO;
        }

        public void DeleteMessage()
        {
            processStorageQueueMessageBO.DeleteMessage();
        }

        public string PeekMessages()
        {
           return processStorageQueueMessageBO.PeekMessages();
        }

        public string SendMessage(string inputMessage)
        {
            return processStorageQueueMessageBO.SendMessage(inputMessage);
        }

        public bool UpdateMessage(string inputMessage)
        {
            return processStorageQueueMessageBO.UpdateMessage(inputMessage);

        }
    }
}
