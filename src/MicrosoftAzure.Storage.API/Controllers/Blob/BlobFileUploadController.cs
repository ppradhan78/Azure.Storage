
namespace MicrosoftAzure.API.Controllers.Blob
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlobFileUploadController : ControllerBase
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        private readonly IBlobServiceCore _blobServiceCore;
        private readonly ILogger _logger;
        #endregion

        public BlobFileUploadController(IBlobServiceCore blobServiceCore, IConfigurationSettings configuration,
            ILogger<BlobFileUploadController> logger)
        {
            _blobServiceCore = blobServiceCore;
            _configuration = configuration;
            _logger = logger;
        }

        #region FileUpload
        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadBlobs()
        {
            try
            {
                IFormFile file = Request.Form.Files[0];
                if (file == null)
                {
                    return BadRequest();
                }
                var output = await _blobServiceCore.UploadFileBlobAsync(file.OpenReadStream(), file.FileName);
                return Ok(output);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("githubupload")]
        public async Task<IActionResult> UploadReports([FromForm] UploadReportsRequest request)
        {
            try
            {
                string[] documentNames = request.DocumentName.Split(',');
                string[] documentURL = request.DocumentURL.Split(',');
                for (int i = 0; i < documentNames.Length; i++)
                {
                    byte[] documentBytes;
                    string documentUrl = documentURL[i];
                    using (HttpClient client = new HttpClient())
                    {
                        if (documentUrl.Contains("github.com"))
                        {
                            documentUrl = documentUrl.Replace("github.com", "raw.githubusercontent.com");
                            documentUrl = documentUrl.Replace("/blob", string.Empty);
                        }
                        documentBytes = await client.GetByteArrayAsync(documentUrl);
                    }

                    await using (MemoryStream stream = new MemoryStream(documentBytes))
                    {
                        string documentName = documentNames[i];
                        if (!documentName.Contains(".pdf"))
                        {
                            documentName = documentName + ".pdf";
                        }
                        var output = await _blobServiceCore.UploadFileBlobAsync(stream, documentName);
                        //if (output != null)
                        //{
                        //    var isRunAndCheckIndexer = _azureAISearchServicesCore.RunAndCheckIndexer();
                        //}
                    }
                }
                return Ok(new { status = "Document Uploaded Successfully", message = "Documents uploaded successfully", trackerId = Guid.NewGuid().ToString() });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("directoryupload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadBlobs(string DirectoryPath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(DirectoryPath))
                {
                    return BadRequest();
                }
                else
                {
                    if (Directory.Exists(DirectoryPath))
                    {
                        string[] fileEntries = Directory.GetFiles(DirectoryPath);
                        foreach (string fileName in fileEntries)
                        {
                            string FileName = Path.GetFileName(fileName);
                            var fileStream = System.IO.File.OpenRead(fileName);
                            if (fileStream == null)
                            {
                                return BadRequest();
                            }
                            else
                            {
                                var output = await _blobServiceCore.UploadFileBlobAsync(fileStream, FileName);
                            }
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("fileupload"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFileBlobs(string FilePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(FilePath))
                {
                    return BadRequest();
                }
                else
                {
                    if (System.IO.File.Exists(FilePath))
                    {
                        string FileName = Path.GetFileName(FilePath);
                        using (var fileStream = System.IO.File.OpenRead(FilePath))
                        {
                            if (fileStream == null)
                            {
                                return BadRequest();
                            }
                            else
                            {
                                var output = await _blobServiceCore.UploadFileBlobAsync(fileStream, FileName);
                                //if (output != null)
                                //{
                                //    var isRunAndCheckIndexer = _azureAISearchServicesCore.RunAndCheckIndexer();
                                //}
                                return Ok(output);
                            }
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion
        [HttpGet()]
        public async Task<IActionResult> BlobFileList()
        {
            var output = await _blobServiceCore.GetBlobFileListAsync();
            return Ok(output);
        }
        [HttpDelete()]
        public async Task<IActionResult> DeleteBlobFileList(string fileName)
        {
             _blobServiceCore.DeleteContainers(fileName);
            return Ok();
        }
    }
}
