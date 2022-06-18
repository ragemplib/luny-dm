using System;
using GTANetworkAPI;
using GTANetworkMethods;
using Player = GTANetworkAPI.Player;

namespace server.Authorization {
    public class AuthorizationCommands : Script {
        [Command(command: "reg", Description = "Register new account")]
        public void OnRegistration(Player player, string login, string email, string password) {
            NAPI.Util.ConsoleOutput("reg");
        }

        [Command(command: "log", Description = "Login into account")]
        public void OnAuth(Player player, string login, string password) {
            NAPI.Util.ConsoleOutput("log");
        }
    }
}