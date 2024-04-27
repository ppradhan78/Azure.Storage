namespace MicrosoftAzure.Storage.Data.BusinessObject.AISearch
{
    public interface IAzureAISearchServicesBO
    {
        Task<List<AzureAISearchModel>> Search(string searchText);
        bool RunAndCheckIndexer();
    }
}
