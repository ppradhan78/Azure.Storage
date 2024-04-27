namespace MicrosoftAzure.Storage.Data.BusinessObject
{
    public class ConfigurationSettings : IConfigurationSettings
    {
        #region Global Variable(s)
        private readonly IConfiguration _configuration;
        #endregion

        public ConfigurationSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Public Prop(s)
        public string AzureAIServiceName => _configuration["AzureAISearch:AzureAIServiceName"];
        public string AzureAIServiceIndexName => _configuration["AzureAISearch:AzureAIServiceIndexName"];
        public string AzureAIServiceApiKey => _configuration["AzureAISearch:AzureAIServiceApiKey"];
        public string AzureAIServiceUrl => _configuration["AzureAISearch:AzureAIServiceUrl"];
        public string AzureAISearchIndexerName => _configuration["AzureAISearch:AzureAISearchIndexerName"];


        public string StorageConnectionString => _configuration["AzureStorage:StorageConnectionString"];
        public string StorageBlobContainerName => _configuration["AzureStorage:StorageBlobContainerName"];
        public string StorageAccountName => _configuration["AzureStorage:StorageAccountName"];
        public string StorageAccountKey => _configuration["AzureStorage:StorageAccountKey"];
        public string StorageUri => _configuration["AzureStorage:StorageUri"];

        
        public string OpenAIApiBase => _configuration["OpenAI:OpenAIApiBase"];
        public string OpenAIKey => _configuration["OpenAI:OpenAIKey"];
        public string OpenAIDeploymentId => _configuration["OpenAI:OpenAIDeploymentId"];
        public string QueueName => _configuration["AzureStorage:QueueName"];


        public string shareName => _configuration["AzureStorage:FileShare:shareName"];
        public string dirName => _configuration["AzureStorage:FileShare:dirName"];
        public string sourceFilePath => _configuration["AzureStorage:FileShare:sourceFilePath"];
        public string destinationFilePath => _configuration["AzureStorage:FileShare:destinationFilePath"];
        public string fileName => _configuration["AzureStorage:FileShare:fileName"];

        #endregion

    }
}
