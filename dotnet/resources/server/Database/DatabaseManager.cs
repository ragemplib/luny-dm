using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GTANetworkAPI;
using Npgsql;

namespace server.Database {
    public static class DatabaseManager {
        private const string ConnString = "Host=127.0.0.1;Username=postgres;Password=postgres;Database=luny";
        private static readonly NpgsqlConnection Conn = new NpgsqlConnection(ConnString);

        public static async Task RegisterPlayer(string login, string email, string password) {
            try {
                await Conn.OpenAsync();

            await using var cmd = new NpgsqlCommand("INSERT INTO players (login, email, password) VALUES ($1, $2, $3)", Conn);
            cmd.Parameters.AddWithValue(login);
            cmd.Parameters.AddWithValue(email);
            cmd.Parameters.AddWithValue(password);
            await cmd.ExecuteNonQueryAsync();

            await Conn.CloseAsync();
            } catch(Exception e) {
                NAPI.Util.ConsoleOutput("err: " + e);
            }

        }
    }
}