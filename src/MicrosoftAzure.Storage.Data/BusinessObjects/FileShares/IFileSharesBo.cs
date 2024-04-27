namespace MicrosoftAzure.Storage.Data.BusinessObject.FileShares
{
    public interface IFileSharesBo
    {
        void UploadFileAsync();
        void DownloadFileAsync();
        void ShareFileAsync();
    }
}