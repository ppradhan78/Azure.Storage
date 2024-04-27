
namespace MicrosoftAzure.Storage.Data.BusinessObjects.Queue
{
    public interface IProcessStorageQueueMessageBO
    {
        string SendMessage(string inputMessage);
        string PeekMessages();
        void DeleteMessage();
        bool UpdateMessage(string inputMessage);
    }
}
