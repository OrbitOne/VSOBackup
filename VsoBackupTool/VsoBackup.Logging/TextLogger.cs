using log4net;
using log4net.Config;

namespace VsoBackup.Logging
{
    public class TextLogger : ILogger
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TextLogger));

        public TextLogger()
        {
            XmlConfigurator.Configure();
        }

        public void WriteLog(string message, params object[] args)
        {
            _logger.InfoFormat(message, args);
        }
    }
}
