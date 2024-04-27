
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;
using System.IO;

namespace MicrosoftAzure.Storage.Data.BusinessObject.FileShares
{
    public class FileSharesBo : IFileSharesBo
    {
        private readonly IConfigurationSettings _configuration;

        public FileSharesBo(IConfigurationSettings configuration)
        {
            _configuration = configuration;
        }

        public void DownloadFileAsync()
        {
            //ToDo it should be azuure dir
            if (Directory.Exists(_configuration.sourceFilePath))
            {
                string[] fileEntries = Directory.GetFiles(_configuration.sourceFilePath);
                foreach (string fileName in fileEntries)
                {
                    var directory = GetShareDirectoryClient();
                    var file = directory.GetFileClient(Path.GetFileName(fileName));
                    ShareFileDownloadInfo download = file.Download();
                    using (FileStream stream = File.OpenWrite(fileName))
                    {
                        download.Content.CopyTo(stream);
                    }
                }
            }
        }

        public void ShareFileAsync()
        {
            ShareClient share = new ShareClient(_configuration.StorageConnectionString, _configuration.shareName);
            var remaining = new Queue<ShareDirectoryClient>();
            remaining.Enqueue(share.GetRootDirectoryClient());
            while (remaining.Count > 0)
            {
                ShareDirectoryClient dir = remaining.Dequeue();
                foreach (ShareFileItem item in dir.GetFilesAndDirectories())
                {
                    if (item.IsDirectory)
                    {
                        remaining.Enqueue(dir.GetSubdirectoryClient(item.Name));
                    }
                }
            }
        }

        public void UploadFileAsync()
        {
            if (Directory.Exists(_configuration.sourceFilePath))
            {
                string[] fileEntries = Directory.GetFiles(_configuration.sourceFilePath);
                foreach (string fileName in fileEntries)
                {
                    var directory = GetShareDirectoryClient();
                    var file= directory.GetFileClient(Path.GetFileName(fileName));
                    using (FileStream stream = File.OpenRead(fileName))
                    {
                        file.Create(stream.Length);
                        var output = file.UploadRange(new HttpRange(0, stream.Length), stream);
                    }
                }
              
            }
        }

        public void DeleteFileAsync(string fileName)
        {
            ShareFileClient client = new ShareFileClient(_configuration.StorageConnectionString, _configuration.shareName, fileName);
            client.DeleteIfExistsAsync();
        }

        //private ShareFileClient GetShareFileClient()
        //{
        //    ShareClient share = new ShareClient(_configuration.StorageConnectionString, _configuration.shareName);
        //    share.CreateIfNotExistsAsync();
        //    ShareDirectoryClient directory = share.GetDirectoryClient(_configuration.dirName);

        //    directory.CreateIfNotExistsAsync();
        //    return directory.GetFileClient(fileName);
        //}

        private ShareDirectoryClient GetShareDirectoryClient()
        {
            ShareClient share = new ShareClient(_configuration.StorageConnectionString, _configuration.shareName);
            share.CreateIfNotExistsAsync();
            ShareDirectoryClient directory = share.GetDirectoryClient(_configuration.dirName);

            return directory;
        }
    }
}