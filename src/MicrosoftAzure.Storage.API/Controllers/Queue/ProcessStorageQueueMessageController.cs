using MicrosoftAzure.Storage.Data.Core.Queue;

namespace MicrosoftAzure.Storage.API.Controllers.Queue
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessStorageQueueMessageController : ControllerBase
    {
        IProcessStorageQueueMessageCore processStorageQueueMessageCore;
        public ProcessStorageQueueMessageController(IProcessStorageQueueMessageCore _processStorageQueueMessageCore)
        {
            this.processStorageQueueMessageCore = _processStorageQueueMessageCore;
        }
        [HttpGet]
        //public IEnumerable<string> Get()
        public string Get()
        {
           return processStorageQueueMessageCore.PeekMessages();
        }
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    processStorageQueueMessageCore.PeekMessages();
        //}
        [HttpPost]
        public string Post(string value)
        {
            return processStorageQueueMessageCore.SendMessage(value);
        }
        //[HttpPut("{id}")]
        [HttpPut()]
        public bool Put(string value)
        {
            return processStorageQueueMessageCore.UpdateMessage(value);
        }
        //[HttpDelete("{id}")]
        [HttpDelete()]
        //public void Delete(int id)
        public void Delete()
        {
            processStorageQueueMessageCore.DeleteMessage();
        }
    }
}
