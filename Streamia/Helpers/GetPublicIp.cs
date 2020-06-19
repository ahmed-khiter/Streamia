using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Streamia.Helpers
{
    public class GetPublicIp
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl;

        public GetPublicIp()
        {
            httpClient = new HttpClient();
            apiUrl = "https://api.ipify.org/?format=json";
        }

        public async Task<string> GetIPV4()
        {
            HttpResponseMessage message = await httpClient.GetAsync(apiUrl);
            string jsonString = await message.Content.ReadAsStringAsync();
            var jsonObject = JsonConvert.DeserializeObject<IDictionary<string, string>>(jsonString);
            return jsonObject["ip"];
        }
    }
}
