using System.Threading.Tasks;

namespace VsoBackup.VisualStudioOnline
{
    public interface IVsoRestApiService
    {
        Task<T> ExecuteRequest<T>(string url);
    }
}
