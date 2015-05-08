using Castle.Windsor;

namespace VsoBackup.DependencyInjection
{
    public class Bootstrapper
    {
        public IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer().Install(new VsoBackupInstaller());
        }
    }
}
