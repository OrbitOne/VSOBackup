using VsoBackup.Models;

namespace VsoBackup.Services
{
    public interface IGitService
    {
        void Clone(Value value, string path);
    }
}
