using JobTrackerAPI.Models;

namespace JobTrackerAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User pUser);
        Task<User> GetUserByEmailAsync(string pEmail);
        Task<Boolean> EmailExistsAsync(string pEmail);
    }
}
