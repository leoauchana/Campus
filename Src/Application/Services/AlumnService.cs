using Application.DTOs;
using Application.Interfaces;

namespace Application.Services;

public class AlumnService : IAlumnService
{
    public AlumnService()
    {
        
    }

    public Task<AlumnDto.Request?> Create(AlumnDto.Request alumnDto)
    {
        throw new NotImplementedException();
    }

    public Task<AlumnDto.Response?> Update(AlumnDto.Request alumnDto)
    {
        throw new NotImplementedException();
    }

    public Task<AlumnDto.Response?> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<AlumnDto.Response?> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<List<AlumnDto.Response>?> GetAll()
    {
        throw new NotImplementedException();
    }
}