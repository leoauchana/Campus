using Application.DTOs;
using Application.Interfaces;

namespace Application.Services;

public class AuthService : IAuthService
{
    public AuthService()
    {
        
    }
    public Task<UserDto.Response> Login(UserDto.Request request)
    {
        throw new NotImplementedException();
    }
}