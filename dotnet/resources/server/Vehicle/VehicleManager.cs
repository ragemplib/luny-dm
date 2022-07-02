using System;
using System.Collections.Generic;
using GTANetworkAPI;
using GTANetworkMethods;
using server.Util;
using Task = System.Threading.Tasks.Task;

namespace server.Vehicle {
    public class VehicleManager : Script {
        [ServerEvent(Event.VehicleDeath)]
        public void OnVehicleDeath(GTANetworkAPI.Vehicle vehicle) {
            AsyncUtil.RunAsyncTask(
                async () =>
                    await HttpUtil.PostRequest(
                        Environment.GetEnvironmentVariable("DISCORD_URL"),
                        new Dictionary<string, string>() { {"content", "Vehicle Death" } })
                );
            AsyncUtil.RunAsyncTask(vehicle.Delete, 15000);
        }
    }
}