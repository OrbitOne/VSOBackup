using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using VsoBackup.Configuration;
using VsoBackup.Logging;
using VsoBackup.Models;
using VsoBackup.Utilities;

namespace VsoBackup.Services
{
   public class FileSystemService : IFileSystemService
   {
       private readonly IAllConfiguration _allConfiguration;
       private readonly ILogger _logger;
       private readonly string _basePath = "";
       public FileSystemService(IAllConfiguration allConfiguration,ILogger logger)
       {
           _allConfiguration = allConfiguration;
           _logger = logger;
           _basePath = _allConfiguration.FileSystemConfiguration.BasePath;
       }

       public bool FolderExists(string folderPath)
       {
           var exists = Directory.Exists(_basePath + folderPath);
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
           var exists = Directory.Exists(_basePath + path);
           return exists;
       }

       public void DeleteFolder(string today)
       {
           var fullPath = _basePath + today;
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
