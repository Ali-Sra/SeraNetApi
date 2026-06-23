using SeraNetApi.Models;

namespace SeraNetApi.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();

    Task<User?> GetByIdAsync(int id);

    Task<User> CreateAsync(User user);

    Task<bool> DeleteAsync(int id);
}
