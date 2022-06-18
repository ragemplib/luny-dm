using System;
using GTANetworkAPI;
using GTANetworkMethods;
using server.Database;
using Player = GTANetworkAPI.Player;
using Task = System.Threading.Tasks.Task;

namespace server.Authorization {
    public class AuthorizationCommands : Script {
        [Command(command: "reg", Description = "Register new account")]
        public async Task OnRegistration(Player player, string login, string email, string password) {
            try {
                await DatabaseManager.RegisterPlayer(login, email, password);
            }
            catch (Exception e) {
                NAPI.Util.ConsoleOutput("err: " + e);
            }

        }

        [Command(command: "log", Description = "Login into account")]
        public void OnAuth(Player player, string login, string password) {
            NAPI.Util.ConsoleOutput("log");
        }
    }
}