using System;
using System.Collections.Generic;
using GTANetworkAPI;
using server.Util;

namespace server.Players {
    public class PlayersRelationshipManager : Script {
        [ServerEvent(Event.PlayerConnected)]
        public void OnPlayerConnected(Player player) {
            NAPI.Player.SpawnPlayer(player, new Vector3(13, 13, 32));
        }

        [ServerEvent(Event.PlayerDeath)]
        public void OnPlayerDeath(Player player, Player killer, uint reasonId) {
            AsyncUtil.RunAsyncTask(
                async () =>
                    await HttpUtil.PostRequest(
                        Environment.GetEnvironmentVariable("DISCORD_URL"),
                        new Dictionary<string, string>() { {"content", $"{player.Name} Death" } })
                );
            NAPI.Player.SpawnPlayer(player, player.Position);
        }
    }
}