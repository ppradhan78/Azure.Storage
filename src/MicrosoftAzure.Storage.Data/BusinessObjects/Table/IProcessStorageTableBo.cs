using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftAzure.Storage.Data.BusinessObjects.Table
{
    public interface IProcessStorageTableBo
    {
        void Create(OrderEntity Input);
        void Update();
        List<OrderEntity> Get(string OrderId);
        List<OrderEntity> GetList(string OrderId);
        void Delete(string partitionKey, string rowKey);

    }
}
