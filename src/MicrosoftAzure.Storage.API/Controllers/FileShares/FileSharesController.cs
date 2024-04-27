
using MicrosoftAzure.Storage.Data.Core.FileShares;

namespace MicrosoftAzure.API.Controllers.FileShares
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSharesController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IFileSharesCore _fileSharesCore;
        private readonly ILogger _logger;
        #endregion

        public FileSharesController(IFileSharesCore fileSharesCore, IConfigurationSettings configuration,
            ILogger<FileSharesController> logger)
        {
            _fileSharesCore = fileSharesCore;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        [Route("UploadFileAsync")]
        public async Task<IActionResult> UploadFileAsync()
        {
            try
            {
                _fileSharesCore.UploadFileAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("DownloadFileAsync")]
        public async Task<IActionResult> DownloadFileAsync()
        {
            try
            {
                  _fileSharesCore.DownloadFileAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("ShareFileAsync")]
        public async Task<IActionResult> ShareFileAsync()
        {
            try
            {
                _fileSharesCore.ShareFileAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
