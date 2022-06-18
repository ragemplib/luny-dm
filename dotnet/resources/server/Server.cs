using System;
using System.Collections.Generic;
using GTANetworkAPI;

using GTANetworkMethods;
using System.Net.Http;
using Task = System.Threading.Tasks.Task;

namespace server
{
    using GTANetworkAPI;
    
    public class Server : Script {
        private static readonly HttpClient webClient = new HttpClient();

        private async Task httpRequest(Log type, String msg) {
            var values = new Dictionary<string, string> {  { "content", $"{type}: {msg}" } };
            var content = new FormUrlEncodedContent(values);

            await webClient.PostAsync(Environment.GetEnvironmentVariable("DISCORD_URL"), content);
        }

        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStartMain()
        {
            NAPI.Util.ConsoleOutput("Server started");
        }

        [ServerEvent(Event.PlayerConnected)]
        public async Task onPlayerConnect(Player player) {
            await httpRequest(Log.Connection, $"{player.Name}  joined the server");

            NAPI.Util.ConsoleOutput("Player " + player.Name + " connected to the server");
        }
        
        [ServerEvent(Event.PlayerDisconnected)]
        public async Task onPlayerDisconnect(Player player) {
            await httpRequest(Log.Disconnect, $"{player.Name}  leaved the server");

            NAPI.Util.ConsoleOutput("Player " + player.Name + " disconnected from the server");
        }

        [Command(command: "time", ACLRequired = false, GreedyArg = false, SensitiveInfo = false)]
        public async Task onPlayerCommand(Player player) {
            await httpRequest(Log.Command, $"{player.Name}  triggered the command");

            NAPI.ClientEvent.TriggerClientEvent(player, "Time");
        }
    }
}
