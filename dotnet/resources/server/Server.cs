using System;
using GTANetworkAPI;

using GTANetworkMethods;

namespace server
{
    using GTANetworkAPI;
    
    public class Server : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStartMain()
        {
            NAPI.Util.ConsoleOutput("Server started");
        }

        [ServerEvent(Event.PlayerConnected)]
        public void onPlayerConnect(Player player) {
            NAPI.Util.ConsoleOutput("Player " + player.Name + " connected to the server");
        }
        
        [ServerEvent(Event.PlayerDisconnected)]
        public void onPlayerDisconnect(Player player) {
            NAPI.Util.ConsoleOutput("Player " + player.Name + " disconnected from the server");
        }

        [Command(command: "time", ACLRequired = false, GreedyArg = false, SensitiveInfo = false)]
        public void onPlayerCommand(Player player) {
            NAPI.ClientEvent.TriggerClientEvent(player, "Time");
        }
    }
}
