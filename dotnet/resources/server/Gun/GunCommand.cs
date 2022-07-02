using GTANetworkAPI;

namespace server.Gun {
    public class GunCommand : Script {
        private readonly GunsManager _gunsManager = new GunsManager();

        [Command(command: "gun")]
        public void OnGun(Player player, string gunName, int ammo) {
            _gunsManager.GiveGun(player, gunName, ammo);
        }
    }
}