using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsoBackup.Configuration
{
    public class FileSystemConfiguration : ConfigurationSection,IFileSystemConfiguration
    {
        [ConfigurationProperty("BasePath", IsRequired = true)]
        public string BasePath
        {
            get { return this["BasePath"].ToString(); }
        }


        [ConfigurationProperty("RemoveBackupAfterHowManyDays", IsRequired = true)]
        public int RemoveBackupAfterHowManyDays
        {
            get { return Convert.ToInt32(this["RemoveBackupAfterHowManyDays"]); }
        }
       

        public static FileSystemConfiguration Load()
        {
            return (FileSystemConfiguration)ConfigurationManager.GetSection("FileSystemConfiguration");
        }
    }
}
