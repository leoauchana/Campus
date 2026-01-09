using Application.DTOs;
using Application.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{

    public EmployeeService()
    {
        
    }
    public Task<UserDto> Create(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> Update(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetById(string id)
    {
        throw new NotImplementedException();
    }
}