using MicrosoftAzure.Storage.Data.Core.Table;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicrosoftAzure.Storage.API.Controllers.Table
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessStorageTableController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IProcessStorageTableCore _processStorageTableCore;
        private readonly ILogger _logger;
        #endregion

        public ProcessStorageTableController(IProcessStorageTableCore processStorageTableCore, IConfigurationSettings configuration,
            ILogger<ProcessStorageTableController> logger)
        {
            _processStorageTableCore = processStorageTableCore;
            _configuration = configuration;
            _logger = logger;
        }

        // GET: api/<ProcessStorageTableController>
        [HttpGet("{id}")]
        public IEnumerable<OrderEntity> Get(string id)
        {
          return  _processStorageTableCore.GetList(id);
        }

        // GET api/<ProcessStorageTableController>/5
        [HttpGet()]
        public string Get()
        {
            return "value";
        }

        // POST api/<ProcessStorageTableController>
        [HttpPost]
        public void Post([FromBody] OrderEntity value)
        {
              _processStorageTableCore.Create(value);

        }

        // PUT api/<ProcessStorageTableController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProcessStorageTableController>/5
        [HttpDelete("{partitionKey}")]
        public void Delete(string partitionKey, string rowKey)
        {
            _processStorageTableCore.Delete(partitionKey, rowKey);
        }
    }
}
