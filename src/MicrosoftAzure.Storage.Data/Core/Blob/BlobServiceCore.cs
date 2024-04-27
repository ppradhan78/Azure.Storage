
namespace MicrosoftAzure.Storage.Data.Core
{
    public class BlobServiceCore : IBlobServiceCore
    {
        #region Global Variable(s)
        private readonly IConfigurationSettings _configuration;
        public readonly IBlobServiceBO _blobService;
        #endregion

        public BlobServiceCore(IBlobServiceBO blobService, IConfigurationSettings configuration)
        {
            _blobService = blobService;
            _configuration = configuration;
        }

        public Task<Uri> UploadFileBlobAsync(Stream content, string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName) && content!=null)
            {
                return _blobService.UploadFileBlobAsync(content, fileName);
            }
            else
            {
                throw new Exception(CommonConstants.InputFile);
            }
         
        }

        public Task<List<BlobServiceOutputModel>> GetBlobFileListAsync()
        {
            return _blobService.GetBlobFileListAsync();
        }

        public void DeleteContainers(string uniqueFileIdentifier)
        {
             _blobService.DeleteContainers(uniqueFileIdentifier);
        }
    }
}
