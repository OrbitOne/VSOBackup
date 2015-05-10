using System;
using VsoBackup.DependencyInjection;
using VsoBackup.Logging;
using VsoBackup.Services;

namespace VsoBackupTool
{
    class Program
    {
        static void Main(string[] args)
        {  
          
                var bootstrapper = new Bootstrapper().BootstrapContainer();
                var backupService = bootstrapper.Resolve<ISourceControlBackupService>();
                var logger = bootstrapper.Resolve<ILogger>();
                
                try
                {
                    backupService.Backup();
                    logger.WriteLog("DONEg");
                }
                catch (Exception ex)
                {
                   logger.WriteLog(ex.ToString());
                   throw;
                }
         
        }
    }
}
