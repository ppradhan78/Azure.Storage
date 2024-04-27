using MicrosoftAzure.Storage.Data.BusinessObject;
using MicrosoftAzure.Storage.Data.BusinessObject.AISearch;
using MicrosoftAzure.Storage.Data.Constants;
using MicrosoftAzure.Storage.Data.SampleModel;

namespace MicrosoftAzure.Storage.Data.Core.AISearch
{
    public class AzureAISearchServicesCore : IAzureAISearchServicesCore
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        public readonly IAzureAISearchServicesBO _AzureAISearchServicesBO;
        #endregion

        public AzureAISearchServicesCore(IAzureAISearchServicesBO azureAISearchServicesBO, IConfigurationSettings configuration)
        {
            _AzureAISearchServicesBO = azureAISearchServicesBO;
            _configuration = configuration;
        }
        
        #region Public Method(s)
        public Task<List<AzureAISearchModel>> Search(string search)
        {
            if (!string.IsNullOrWhiteSpace(search))
            {
                return _AzureAISearchServicesBO.Search(search);
            }
            else
            {
                throw new Exception(CommonConstants.InputSearchFailed);
            }
          
        }

        public bool RunAndCheckIndexer()
        {
            return _AzureAISearchServicesBO.RunAndCheckIndexer();
        }
        #endregion
    }
}
