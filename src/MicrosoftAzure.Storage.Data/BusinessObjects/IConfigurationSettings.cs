namespace MicrosoftAzure.Storage.Data.BusinessObject
{
    public interface IConfigurationSettings
    {
        string AzureAIServiceName { get; }
        string AzureAIServiceIndexName { get; }
        string AzureAIServiceApiKey { get; }
        string AzureAIServiceUrl { get; }
        string AzureAISearchIndexerName { get; }

        string StorageConnectionString { get; }
        string StorageBlobContainerName { get; }
        string StorageAccountName { get; }
        string StorageAccountKey { get; }
        string StorageUri { get; }
        
        string QueueName { get; }

        string OpenAIApiBase { get; }
        string OpenAIKey { get; }
        string OpenAIDeploymentId { get; }

        string shareName { get; }
        string dirName { get; }
        string fileName { get; }
        string sourceFilePath { get; }
        string destinationFilePath { get; }



    }
}
