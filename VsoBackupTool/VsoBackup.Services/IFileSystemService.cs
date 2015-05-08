using VsoBackup.Models;

namespace VsoBackup.Services
{
    public interface IFileSystemService
    {
        bool FolderExists(string folderPath);
        void CreateDirectory(string path);
        bool BackupTreshholdReached(string path);
        void DeleteFolder(string today);
    }
}