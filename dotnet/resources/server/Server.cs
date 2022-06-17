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

        [ServerEvent(Event.ChatMessage)]
        public void onPlayerCommand(Player player, String msg) {
            if (msg[0] == '/') {
                NAPI.Util.ConsoleOutput("Player " + player.Name + " entered the command: " + msg);
            } else {
                NAPI.Util.ConsoleOutput("Player " + player.Name + " entered the message: " + msg);
            }
        }
    }
}
