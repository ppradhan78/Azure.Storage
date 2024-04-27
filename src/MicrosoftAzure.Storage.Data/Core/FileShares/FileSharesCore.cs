
using MicrosoftAzure.Storage.Data.BusinessObject.FileShares;

namespace MicrosoftAzure.Storage.Data.Core.FileShares
{
    public class FileSharesCore : IFileSharesCore
    {
        private readonly IConfigurationSettings _configuration;
        IFileSharesBo _fileSharesBo;
        public FileSharesCore( IConfigurationSettings configuration, IFileSharesBo fileSharesBo)
        {
            _configuration = configuration;
            _fileSharesBo = fileSharesBo;
        }

        public void DownloadFileAsync()
        {
            _fileSharesBo.DownloadFileAsync();
        }

        public void ShareFileAsync()
        {
            _fileSharesBo.ShareFileAsync();

        }

        public void UploadFileAsync()
        {
            _fileSharesBo.UploadFileAsync();

        }
    }
}