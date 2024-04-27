using MicrosoftAzure.Storage.Data.BusinessObjects.Table;

namespace MicrosoftAzure.Storage.Data.Core.Table
{
    public class ProcessStorageTableCore: IProcessStorageTableCore
    {
        IProcessStorageTableBo _processStorageTableBo;
        private readonly IConfigurationSettings _configuration;

        public ProcessStorageTableCore(IProcessStorageTableBo processStorageTableBo, IConfigurationSettings configuration)
        {
            _processStorageTableBo = processStorageTableBo;
            _configuration = configuration;
        }

        public void Create(OrderEntity Input)
        {
            _processStorageTableBo.Create(Input);
        }

        public List<OrderEntity> Get(string OrderId)
        {
            return _processStorageTableBo.GetList(OrderId);

        }

        public List<OrderEntity> GetList(string OrderId)
        {
           return _processStorageTableBo.GetList(OrderId);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete(string partitionKey, string rowKey)
        {
            _processStorageTableBo.Delete(partitionKey, rowKey);
        }
    }
}
