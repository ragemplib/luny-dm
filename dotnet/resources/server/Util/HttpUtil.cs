using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace server.Util {
    public static class HttpUtil {
        private static readonly HttpClient WebClient = new HttpClient();

        public static async Task PostRequest(string URL, Dictionary<string, string> values) {
            await WebClient.PostAsync(URL, new FormUrlEncodedContent(values));
        }
    }
}