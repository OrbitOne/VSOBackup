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
                
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(string.Format("{0}:{1}", _configuration.VsoConfiguration.ApiUsername, _configuration.VsoConfiguration.ApiPassword))));

                var json = await GetAsync(client, url);
                var test = JsonConvert.DeserializeObject<T>(json);
                return test;
            }
        }
      

        static async Task<String> GetAsync(HttpClient client, String apiUrl)
        {
            var responseBody = "";

                using (HttpResponseMessage response = client.GetAsync(apiUrl).Result)
                {
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }

            return responseBody;
        }
    }
}



