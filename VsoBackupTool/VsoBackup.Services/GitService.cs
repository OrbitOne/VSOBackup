using System.Web;
using LibGit2Sharp;
using VsoBackup.Configuration;
using VsoBackup.Logging;
using VsoBackup.Models;

namespace VsoBackup.Services
{
    public class GitService : IGitService
    {
        private readonly IAllConfiguration _allConfiguration;
        private readonly ILogger _logger;
        private Credentials _credentials;

        public GitService(IAllConfiguration allConfiguration, ILogger logger)
        {
            _allConfiguration = allConfiguration;
            _logger = logger;
        }

        private Credentials CredentialsProvider(string url, string usernameFromUrl, SupportedCredentialTypes types)
        {
            _credentials = new UsernamePasswordCredentials
            {
                Username = _allConfiguration.VsoConfiguration.ApiUsername,
                Password = _allConfiguration.VsoConfiguration.ApiPassword
            };
            return _credentials;
        }

        public void Clone(Value value, string path)
        {
            _logger.WriteLog("Cloning repository '{0}'", value.name);
            Repository.Clone(HttpUtility.UrlPathEncode(value.remoteUrl), path, new CloneOptions
            {
                CredentialsProvider = CredentialsProvider
            });
        }
    }
}
