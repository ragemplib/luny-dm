using GTANetworkAPI;

namespace server.Gun {
    public class GunCommand : Script {
        private readonly GunManager _gunManager = new GunManager();

        [Command(command: "gun")]
        public void OnGun(Player player, string gunName, int ammo) {
            _gunManager.GiveGun(player, gunName, ammo);
        }
    }
}