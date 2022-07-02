using GTANetworkAPI;

namespace server.Server {
    public class ServerConfig : Script {
        public ServerConfig() {
            NAPI.Server.SetAutoRespawnAfterDeath(false);
        }
    }
}