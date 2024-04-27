namespace MicrosoftAzure.Storage.Data.Core
{
    public interface IBlobServiceCore
    {
        Task<Uri> UploadFileBlobAsync(Stream content, string fileName);
        Task<List<BlobServiceOutputModel>> GetBlobFileListAsync();
        void DeleteContainers(string uniqueFileIdentifier);

    }
}
