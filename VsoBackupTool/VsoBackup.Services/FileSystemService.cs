using System.IO;
using VsoBackup.Configuration;
using VsoBackup.Logging;

namespace VsoBackup.Services
{
    public class FileSystemService : IFileSystemService
    {
        private readonly ILogger _logger;
        private readonly string _basePath;

        public FileSystemService(IAllConfiguration allConfiguration, ILogger logger)
        {
            _logger = logger;
            _basePath = allConfiguration.FileSystemConfiguration.BasePath;
        }

        public bool FolderExists(string folderPath)
        {
            var exists = Directory.Exists(Path.Combine(_basePath, folderPath));
            return exists;
        }

        public void CreateDirectory(string path)
        {
            var fullPath = _basePath + path;
            _logger.WriteLog("Created directory '{0}'", fullPath);
            Directory.CreateDirectory(fullPath);
        }

        public bool BackupTreshholdReached(string path)
        {
            var exists = Directory.Exists(Path.Combine(_basePath, path));
            return exists;
        }

        public void DeleteFolder(string today)
        {
            var fullPath = Path.Combine(_basePath, today);
            var directory = new DirectoryInfo(fullPath) { Attributes = FileAttributes.Normal };

            var all = directory.GetFileSystemInfos("*", SearchOption.AllDirectories);
            foreach (var info in all)
            {
                info.Attributes = FileAttributes.Normal;
            }

            File.SetAttributes(fullPath, FileAttributes.Normal);
            _logger.WriteLog("Deleting directory '{0}'", fullPath);
            Directory.Delete(fullPath, true);
        }
    }
}
