using GTANetworkAPI;

namespace server.Vehicle {
    public class VehicleManager : Script {
        [ServerEvent(Event.VehicleDeath)]
        public void OnVehicleDeath(GTANetworkAPI.Vehicle vehicle) {
            vehicle.Delete();
        }
    }
}