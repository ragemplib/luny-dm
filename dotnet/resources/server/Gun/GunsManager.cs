using GTANetworkAPI;

namespace server.Gun {
    public class GunsManager {
        public void GiveGun(Player player, string gunName, int ammo) {
            NAPI.Player.GivePlayerWeapon(player, GetGunHash(gunName), ammo);
        }

        private WeaponHash GetGunHash(string gunName) {
            return NAPI.Util.WeaponNameToModel(gunName);
        }
    }
}