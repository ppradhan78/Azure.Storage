using Azure.Data.Tables;
using Newtonsoft.Json;
using System;

namespace MicrosoftAzure.Storage.Data.SimpleModels
{
    // Define a strongly typed entity by implementing the ITableEntity interface.
    public class OfficeSupplyEntity : ITableEntity
    {
        public string Product { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
    // Define a strongly typed entity by implementing the ITableEntity interface.
    public class OrderEntity : ITableEntity
    {

        public string OrderID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string CustomerID { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public string PartitionKey { get; set; } = Guid.NewGuid().ToString();
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
