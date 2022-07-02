using RAGE;
using RAGE.Game;

namespace clientside.Utils.Discord {
    public class DiscordManager : Events.Script {
        public DiscordManager() {
            RAGE.Discord.Update("Luny", "Developing some game!");
        }
    }
}