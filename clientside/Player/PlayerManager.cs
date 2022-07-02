using RAGE;
using static clientside.Ped.PositionUtils;
using static clientside.Player.PlayerUtils;

namespace clientside.Player {
    public static class PlayerManager {
        public static void OnPlayerConnection() {
            FreezePedPosition(GetCurrentPlayerId());
        }
    }
}