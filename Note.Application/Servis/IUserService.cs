using Note.Domain.Models;

namespace Note.Application.Servis
{
    public interface IUserService
    {
        Task<bool> CheckUserAsync(Guid UserId);
        Task<bool> AddUserAsync(User user);
        Task<bool> DeleteUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
