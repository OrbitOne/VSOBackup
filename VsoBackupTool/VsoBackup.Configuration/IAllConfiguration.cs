namespace VsoBackup.Configuration
{
    public interface IAllConfiguration
    {
        IFileSystemConfiguration FileSystemConfiguration { get; }
        IVsoConfiguration VsoConfiguration { get; }
    }
}
