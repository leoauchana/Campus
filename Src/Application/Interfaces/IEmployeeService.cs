using Application.DTOs;

namespace Application.Interfaces;

public interface IEmployeeService
{
    Task<UserDto> Create(UserDto userDto);
    Task<UserDto> Update(UserDto userDto);
    Task Delete(UserDto userDto);
    Task<List<UserDto>> GetAll();
    Task<UserDto> GetById(string id);
}