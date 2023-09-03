using Npgsql;

namespace Note.Application.Servis
{
    public interface INoteDbContext
    {
        Task<int> ExecuteCommandAsync(string command);
        Task<NpgsqlDataReader> ExecuteQueryAsync(string getAllQuery);
    }
}
