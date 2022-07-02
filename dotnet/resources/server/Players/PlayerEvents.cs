using System.Net;
using GTANetworkAPI;
using server.Util;
using static server.Players.PlayerEventEnum;

namespace server.Players {
    public class PlayerEvents : Script {
        [ServerEvent(Event.PlayerConnected)]
        public async void OnPlayerConnected(Player player) {
            AsyncUtil.RunAsyncTask( async () => await HttpUtil.DiscordRequest($"{player.Name} PlayerConnected"));

            NAPI.ClientEvent.TriggerClientEvent(player, PlayerConnection.ToString());
        }

        [ServerEvent(Event.PlayerDisconnected)]
        public async void OnPlayerDisconnected(Player player) {
            AsyncUtil.RunAsyncTask( async () => await HttpUtil.DiscordRequest($"{player.Name} PlayerDisconnected"));
        }

        [ServerEvent(Event.PlayerSpawn)]
        public async void OnPlayerSpawn(Player player) {
             AsyncUtil.RunAsyncTask(  async () => await HttpUtil.DiscordRequest($"{player.Name} PlayerSpawn"));
        }
    }
}