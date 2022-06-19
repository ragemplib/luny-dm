using System;
using System.Threading.Tasks;
using GTANetworkAPI;
using Npgsql;

namespace server.Database {
    public static class DatabaseManager {
        public static async Task RegisterPlayer(String login, String email, String password) {
            try {
                var connString = "Host=127.0.0.1;Username=postgres;Password=postgres;Database=luny";

                await using var conn = new NpgsqlConnection(connString);
                await conn.OpenAsync();

                // Insert some data
                await using (var cmd = new NpgsqlCommand($"INSERT INTO players (login, email, password) VALUES ('{login}', '{email}', '{password}')", conn))
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                await conn.CloseAsync();

            } catch(Exception e) {
                NAPI.Util.ConsoleOutput("err: " + e);
            }

        }
    }
}