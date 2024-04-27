namespace MicrosoftAzure.Storage.Data.Core.FileShares
{
    public interface IFileSharesCore
    {
        void UploadFileAsync();
        void DownloadFileAsync();
        void ShareFileAsync();
    }
}