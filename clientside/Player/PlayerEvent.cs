using RAGE;
using RAGE.Game;
using static clientside.Player.PlayerEventEnum;
using static clientside.Player.PlayerManager;

namespace clientside.Player {
    public class PlayerEvent : Events.Script {
        public PlayerEvent() {
            // Events.Add(PlayerConnection.ToString(), OnPlayerConnection);
            OnPlayerConnection();
        }
    }
}