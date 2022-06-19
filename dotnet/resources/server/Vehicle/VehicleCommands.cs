using GTANetworkAPI;

namespace server.Vehicle {
    public class VehicleCommands : Script {
        [Command(command: "veh")]
        public void SpawnVehicle(Player player, string vehicleName) {
            VehicleItem veh = new VehicleItem(player.Position, vehicleName);
            veh.SpawnCar();
        }
    }
}