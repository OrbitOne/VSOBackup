using System.Configuration;

namespace VsoBackup.Configuration
{
    public interface IVsoConfiguration
    {
        string ApiUsername { get; }
        string ApiPassword { get; }
        string AllRepositoriesUrl { get; }
    }
}