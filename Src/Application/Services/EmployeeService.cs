using Application.DTOs;
using Application.Interfaces;

namespace Application.Services;

public class EmployeeService : IEmployeeService
{
    
    public EmployeeService()
    {
        
    }

    public async Task<EmployeeDto.Response?> Create(EmployeeDto.Request employeeDto)
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto.Response> Update(EmployeeDto.Request employeeDto)
    {
        throw new NotImplementedException();
    }

    public async Task Delete(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<EmployeeDto.Response>?> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeDto.Response?> GetById(string id)
    {
        throw new NotImplementedException();
    }

}