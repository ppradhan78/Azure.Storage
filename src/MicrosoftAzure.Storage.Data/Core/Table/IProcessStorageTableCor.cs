namespace MicrosoftAzure.Storage.Data.Core.Table
{
    public interface IProcessStorageTableCore
    {
        void Create(OrderEntity Input);
        void Update();
        List<OrderEntity> Get(string OrderId);
        List<OrderEntity> GetList(string OrderId);
        void Delete(string partitionKey, string rowKey);

    }
}
