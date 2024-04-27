
namespace MicrosoftAzure.Storage.Data.BusinessObject.Blobs
{
    public class BlobServiceBO : IBlobServiceBO
    {
        private readonly IConfigurationSettings _configuration;

        public BlobServiceBO( IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<BlobServiceOutputModel>> GetBlobFileListAsync()
        {
            var filelist = new List<BlobServiceOutputModel>();
            var containerClient = GetContainerClient(_configuration.StorageBlobContainerName);
            try
            {
                var resultSegment = containerClient.GetBlobsAsync().AsPages();

                await foreach (Page<BlobItem> blobPage in resultSegment)
                {
                    foreach (BlobItem blobItem in blobPage.Values)
                    {
                        filelist.Add(new BlobServiceOutputModel { BlobName = blobItem.Name  , VersionId = blobItem.VersionId });
                    }

                }
                return filelist;
            }
            catch (RequestFailedException e)
            {
                throw;
            }
        }

        public async Task<Uri> UploadFileBlobAsync(Stream content,  string fileName)
        {
            try
            {
                var containerClient = GetContainerClient(_configuration.StorageBlobContainerName);
                var blobClient = containerClient.GetBlobClient(fileName);
                await blobClient.UploadAsync(content,overwrite:true);
                return blobClient.Uri;
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        public void DeleteContainers(string uniqueFileIdentifier)
        {
            try
            {
                BlobServiceClient _blobServiceClient = new BlobServiceClient(_configuration.StorageConnectionString);
                var containerClient = _blobServiceClient.GetBlobContainerClient(uniqueFileIdentifier);
                containerClient.DeleteIfExists();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private BlobContainerClient GetContainerClient(string blobContainerName)
        {
            try
            {
                BlobServiceClient _blobServiceClient = new BlobServiceClient(_configuration.StorageConnectionString);
                var containerClient = _blobServiceClient.GetBlobContainerClient(blobContainerName);
                containerClient.CreateIfNotExists();
                return containerClient;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}