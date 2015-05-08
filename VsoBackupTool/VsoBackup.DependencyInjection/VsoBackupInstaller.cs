using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using VsoBackup.Configuration;
using VsoBackup.Services;
using VsoBackup.VisualStudioOnline;
using VsoBackup.Logging;
 
namespace VsoBackup.DependencyInjection
{
   public class VsoBackupInstaller : IWindsorInstaller
    {
       public void Install(IWindsorContainer container, IConfigurationStore store)
       {
           container.Register(
               Component.For<IAllConfiguration>().ImplementedBy<AllConfiguration>(),
               Component.For<IVsoRestApiService>().ImplementedBy<VsoRestApiService>(),
               Component.For<IFileSystemService>().ImplementedBy<FileSystemService>(),
               Component.For<ILogger>().ImplementedBy<TextLogger>(),
               Component.For<ISourceControlBackupService>().ImplementedBy<SourceControlBackupService>(),
               Component.For<IGitService>().ImplementedBy<GitService>());
       }
    }
}
