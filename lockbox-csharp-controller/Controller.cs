using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace lockbox_csharp_controller
{
    internal class Controller
    {
        private static readonly HttpClient client = new HttpClient();

        public Task<string> GetInfoAsync(string ip, int port)
        {
            return client.GetStringAsync("http://" + ip + ":" + port.ToString() + "/settings");
        }

        public async Task<String> LockAsync(string ip, int port, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "password", password }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://" + ip + ":" + port.ToString() + "/lock", content);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<String> UnlockAsync(string ip, int port, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "password", password }
            };
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync("http://" + ip + ":" + port.ToString() + "/unlock", content);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
