using Application.DTOs;

namespace Application.Interfaces;

public interface IAlumnService
{
    Task<AlumnDto.Request?> Create(AlumnDto.Request alumnDto);
    Task<AlumnDto.Response?> Update(AlumnDto.Request alumnDto);
    Task<AlumnDto.Response?> Delete(string id);
    Task<AlumnDto.Response?> GetById(string id);
    Task<List<AlumnDto.Response>?> GetAll();
}