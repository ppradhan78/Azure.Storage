using Azure.Data.Tables;
using System.Collections.Concurrent;

namespace MicrosoftAzure.Storage.Data.BusinessObjects.Table
{
    public class ProcessStorageTableBo : IProcessStorageTableBo
    {
        private readonly IConfigurationSettings _configuration;
        public ProcessStorageTableBo(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public void Create(OrderEntity Input)
        {
            var tableClient = CreateTableServiceClient();
            var tableEntity = new OrderEntity()
            {
                CustomerID = Input.CustomerID,
                EmployeeID = Input.EmployeeID,
                Freight = Input.Freight,
                OrderDate = Input.OrderDate,
                OrderID = Input.OrderID,
                RequiredDate = Input.RequiredDate,
                ShipAddress = Input.ShipAddress,
                ShipCity = Input.ShipCity,
                ShipCountry = Input.ShipCountry,
                ShipName = Input.ShipName,
                ShippedDate = Input.ShippedDate,
                ShipPostalCode = Input.ShipPostalCode,
                ShipRegion = Input.ShipRegion,
                ShipVia = Input.ShipVia,
                PartitionKey=Guid.NewGuid().ToString(),
                RowKey=Guid.NewGuid().ToString()

            };
            tableClient.AddEntity(tableEntity);
        }

        public void Delete(string partitionKey, string rowKey)
        {
            var tableClient=CreateTableServiceClient();
            tableClient.DeleteEntity(partitionKey, rowKey);
        }

        public List<OrderEntity> Get(string OrderId)
        {
            var output = new List<OrderEntity>();
            var tableClient = CreateTableServiceClient();
            Pageable<OrderEntity> queryResultsLINQ = tableClient.Query<OrderEntity>(ent => ent.OrderID == OrderId);

            foreach (var item in queryResultsLINQ)
            {
                output.Add(new OrderEntity()
                {
                    CustomerID = item.CustomerID,
                    EmployeeID = item.EmployeeID,
                    Freight = item.Freight,
                    OrderDate = item.OrderDate,
                    OrderID = item.OrderID,
                    RequiredDate = item.RequiredDate,
                    ShipAddress = item.ShipAddress,
                    ShipCity = item.ShipCity,
                    ShipCountry = item.ShipCountry,
                    ShipName = item.ShipName,
                    ShippedDate = item.ShippedDate,
                    ShipPostalCode = item.ShipPostalCode,
                    ShipRegion = item.ShipRegion,
                    ShipVia = item.ShipVia,
                });
            }
            return output;

        }

        public List<OrderEntity> GetList(string OrderId)
        {
            var output = new List<OrderEntity>();
            var tableClient = CreateTableServiceClient();

            Pageable<OrderEntity> queryResultsFilter = tableClient.Query<OrderEntity>(ent => ent.OrderID == OrderId);

            // Iterate the <see cref="Pageable"> to access all queried entities.
            foreach (OrderEntity item in queryResultsFilter)
            {
                output.Add(new OrderEntity()
                {
                    CustomerID = item.CustomerID,
                    EmployeeID = item.EmployeeID,
                    Freight = item.Freight,
                    OrderDate = item.OrderDate,
                    OrderID = item.OrderID,
                    RequiredDate = item.RequiredDate,
                    ShipAddress = item.ShipAddress,
                    ShipCity = item.ShipCity,
                    ShipCountry = item.ShipCountry,
                    ShipName = item.ShipName,
                    ShippedDate = item.ShippedDate,
                    ShipPostalCode = item.ShipPostalCode,
                    ShipRegion = item.ShipRegion,
                    ShipVia = item.ShipVia,
                    //CustomerID = item.GetString("CustomerID"),
                    //ShipAddress = item.GetString("ShipAddress"),
                    //ShipCity = item.GetString("ShipCity"),
                    //ShipCountry = item.GetString("ShipCountry"),
                    //ShipName = item.GetString("ShipName"),
                    //ShipPostalCode = item.GetString("ShipPostalCode"),
                    //ShipRegion = item.GetString("ShipRegion"),

                });
            }

            //Pageable<OrderEntity> queryResultsLINQ = tableClient.Query<OrderEntity>(ent => ent.OrderID == OrderId);

            //foreach (var item in queryResultsLINQ)
            //{
               
            //}
            return output;
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        private TableClient CreateTableServiceClient()
        {
            return new TableClient(new Uri(_configuration.StorageUri ), "Order",
   new TableSharedKeyCredential(_configuration.StorageAccountName, _configuration.StorageAccountKey));
           
        }
    }
}
