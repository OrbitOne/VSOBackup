namespace VsoBackup.Logging
{
    public interface ILogger
    {
        void WriteLog(string message, params object[] args);
    }
}