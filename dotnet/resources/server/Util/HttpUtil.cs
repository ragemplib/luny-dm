using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace server.Util {
    public static class HttpUtil {
        private static readonly HttpClient WebClient = new HttpClient();

        public static async Task PostRequest(string url, Dictionary<string, string> values) {
            await WebClient.PostAsync(url, new FormUrlEncodedContent(values));
        }

        public static async Task<string> DiscordRequest(string content) {
            await WebClient.PostAsync(
                Environment.GetEnvironmentVariable("DISCORD_URL"),
                new FormUrlEncodedContent(
                    new Dictionary<string, string>() { {"content", content } }
                    )
                );
            return "succes";
        }
    }
}