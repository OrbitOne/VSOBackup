using VsoBackup.Models;
using VsoBackup.VisualStudioOnline;

namespace VsoBackup.Services
{
    public interface IGitService
    {
        void Clone(Value value, string path);
    }
}