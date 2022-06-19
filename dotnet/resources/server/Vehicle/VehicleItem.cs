using GTANetworkAPI;

namespace server.Vehicle {
    public class VehicleItem {
        private Vector3 _position;
        private readonly VehicleHash _vehicleHash;
        public VehicleItem(Vector3 position, string vehicleName) {
            _position = position;
            _vehicleHash = NAPI.Util.VehicleNameToModel(vehicleName);
        }
        public void SpawnCar() {
            var veh = NAPI.Vehicle.CreateVehicle(_vehicleHash, new Vector3(_position.X + 2, _position.Y, _position.Z), 0f, 0, 0);
        }
    }
}