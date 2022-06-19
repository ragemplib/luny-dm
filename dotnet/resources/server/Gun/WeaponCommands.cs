using GTANetworkAPI;

namespace Npgsql {
    public class WeaponCommands : Script {
        [Command(command: "gun")]
        public void onGun(Player player) {
            NAPI.Player.GivePlayerWeapon(player, WeaponHash.Advancedrifle, 500);
        }
    }
}