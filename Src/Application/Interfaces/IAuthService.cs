using Application.DTOs;

namespace Application.Interfaces;

public interface IAuthService
{
    Task<UserDto.Response?> Login(UserDto.Request request);
}