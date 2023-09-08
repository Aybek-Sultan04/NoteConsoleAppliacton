using Npgsql;

namespace Note.Application.Servis
{
    public interface INoteDbContext
    {
        Task<int> ExecuteCommandAsync(string command);
        ICollection<Domain.Models.Note> ExecuteQuery(string getAllQuery);
    }
}
