using Note.Domain.Models;

namespace Note.Application.Servis
{
    public interface IUserDbContext
    {
        Task<int> ExecuteCommandAsync(string command);
        ICollection<Domain.Models.User> ExecuteQuery(string getAllQuery);
    }

}
