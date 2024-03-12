
using JoyOfFastDelivery.Models;

namespace JoyOfFastDelivery.Services
{
    public interface IDatabaseService
    {
        Task InitializeAsync();
        Task<User> GetUserAsync(string username);
        Task<int> AddUserAsync(User user);
        Task<int> UpdateUserAsync(User user);
        Task<int> DeleteUserAsync(User user);
    }
}
