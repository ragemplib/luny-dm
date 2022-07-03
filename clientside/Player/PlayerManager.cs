using clientside.Camera;
using RAGE;
using static clientside.Ped.PositionUtils;
using static clientside.Player.PlayerUtils;
using static clientside.UI.UiUtils;

namespace clientside.Player {
    public static class PlayerManager {
        public static void OnPlayerConnection() {
            ChangePositionMutabilityState(GetCurrentPlayerPedId(), true);
            ChangeRadarVisibility(false);
            ChangeChatVisibility(false);
            new CameraManager();
        }
    }
}