using System;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using VsoBackup.Configuration;

namespace VsoBackup.VisualStudioOnline
{
    public class VsoRestApiService : IVsoRestApiService
    {
        private readonly IAllConfiguration _configuration;

        public VsoRestApiService(IAllConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<T> ExecuteRequest<T>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var authenticationHeaderValue = string.Format("{0}:{1}", _configuration.VsoConfiguration.ApiUsername, _configuration.VsoConfiguration.ApiPassword);
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(authenticationHeaderValue)));

                var json = await GetAsync(client, url);
                var test = JsonConvert.DeserializeObject<T>(json); // A variable test named?
                return test;
            }
        }

        private static async Task<String> GetAsync(HttpClient client, String apiUrl)
        {
            string responseBody;

            using (var response = await client.GetAsync(apiUrl))
            {
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }

            return responseBody;
        }
    }
}
