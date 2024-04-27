namespace MicrosoftAzure.Storage.Data.Core.Queue
{
    public interface IProcessStorageQueueMessageCore
    {
        string SendMessage(string inputMessage);
        string PeekMessages();
        void DeleteMessage();
        bool UpdateMessage(string inputMessage);
    }
}
