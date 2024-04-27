namespace MicrosoftAzure.Storage.Data.BusinessObject.Blobs
{
    public interface IBlobServiceBO
    {
        Task<Uri> UploadFileBlobAsync(Stream content,  string fileName);
        Task<List<BlobServiceOutputModel>> GetBlobFileListAsync();
        void DeleteContainers(string uniqueFileIdentifier);
    }
}