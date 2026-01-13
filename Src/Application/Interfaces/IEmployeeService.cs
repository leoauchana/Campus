using Application.DTOs;

namespace Application.Interfaces;

public interface IEmployeeService
{
    Task<EmployeeDto.Response?> Create(EmployeeDto.Request employeeDto);
    Task<EmployeeDto.Response> Update(EmployeeDto.Request employeeDto);
    Task Delete(string id);
    Task<List<EmployeeDto.Response>?> GetAll();
    Task<EmployeeDto.Response?> GetById(string id);
}