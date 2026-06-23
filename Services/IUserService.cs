using SeraNetApi.DTOs;

namespace SeraNetApi.Services;

public interface IUserService
{
    Task<List<UserReadDto>> GetAllAsync();

    Task<UserReadDto?> GetByIdAsync(int id);

    Task<UserReadDto> CreateAsync(UserCreateDto dto);

    Task<bool> DeleteAsync(int id);
}
