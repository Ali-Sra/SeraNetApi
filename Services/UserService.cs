using SeraNetApi.DTOs;
using SeraNetApi.Models;
using SeraNetApi.Repositories;

namespace SeraNetApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserReadDto>> GetAllAsync()
    {
        var users = await _repository.GetAllAsync();

        return users.Select(ToReadDto).ToList();
    }

    public async Task<UserReadDto?> GetByIdAsync(int id)
    {
        var user = await _repository.GetByIdAsync(id);

        return user == null ? null : ToReadDto(user);
    }

    public async Task<UserReadDto> CreateAsync(UserCreateDto dto)
    {
        var user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            CreatedAt = DateTime.Now
        };

        var createdUser = await _repository.CreateAsync(user);

        return ToReadDto(createdUser);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    private static UserReadDto ToReadDto(User user)
    {
        return new UserReadDto
        {
            Id = user.Id,
            FullName = $"{user.FirstName} {user.LastName}",
            Email = user.Email
        };
    }
}
