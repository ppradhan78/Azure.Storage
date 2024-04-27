using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace MicrosoftAzure.Storage.Data.BusinessObjects.Queue
{
    public class ProcessStorageQueueMessageBO : IProcessStorageQueueMessageBO
    {
        private readonly IConfigurationSettings _configuration;

        public ProcessStorageQueueMessageBO(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public void DeleteMessage()
        {
            var queueClient = CreateQueueClient();
            foreach (QueueMessage message in queueClient.ReceiveMessages(maxMessages: 100).Value)
            {
                var output = queueClient.DeleteMessage(message.MessageId, message.PopReceipt);
            }
        }

        public string PeekMessages()
        {
            var queueClient = CreateQueueClient();
            if (queueClient.Exists())
            {
                var peekedMessage = queueClient.PeekMessage();
                return peekedMessage?.Value?.MessageText;
            }
            else return  "";
        }

        public string SendMessage(string inputMessage)
        {
            var queueClient = CreateQueueClient();
            queueClient.SendMessage(inputMessage);
            var output = queueClient.SendMessage(inputMessage);
            return output?.Value.MessageId;
        }

        public bool UpdateMessage(string inputMessage)
        {
            var queueClient = CreateQueueClient();
            if (queueClient.Exists())
            {
                QueueMessage[] message = queueClient.ReceiveMessages();
                var output = queueClient.UpdateMessage(message[0].MessageId, inputMessage);
                return true;
            }
            return false;
        }

        private QueueClient CreateQueueClient()
        {
            return new QueueClient(_configuration.StorageConnectionString, _configuration.QueueName);
        }
    }
}
