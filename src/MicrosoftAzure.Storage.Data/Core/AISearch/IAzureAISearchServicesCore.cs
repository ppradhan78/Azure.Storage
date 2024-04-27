using MicrosoftAzure.Storage.Data.SampleModel;

namespace MicrosoftAzure.Storage.Data.Core.AISearch
{
    public interface IAzureAISearchServicesCore
    {
        Task<List< AzureAISearchModel>> Search(string search);
        bool RunAndCheckIndexer();
    }
}
