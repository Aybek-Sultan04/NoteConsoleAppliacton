using Note.Application.Servis;
using Note.Infrastructure.DbConfiguration;
using Npgsql;

namespace Note.Infrastructure.DbServices
{
    public class DbContext : INoteDbContext
    {
        private static string connectionString = GetConfigFromDb.GetConnect();
        NpgsqlConnection connection = new(connectionString);
        public async Task<int> ExecuteCommandAsync(string command)
        {
            using (connection)
            {
                connection.Open();
                NpgsqlCommand npgsqlCommand = new NpgsqlCommand(command, connection);
                int effectedRows = await npgsqlCommand.ExecuteNonQueryAsync();
                return effectedRows;
            }
        }
        public async Task<NpgsqlDataReader> ExecuteQueryAsync(string getAllQuery)
        {
            using (connection)
            {
                connection.Open();
                NpgsqlCommand npgsqlCommand = new(getAllQuery, connection);
                NpgsqlDataReader reader = await npgsqlCommand.ExecuteReaderAsync();
                return reader;
            }
        }
    }
}
