using Application.DTOs;

namespace Application.Interfaces;

public interface ITeacherService
{
    Task<TeacherDto.Response?> Create(TeacherDto.RequestCreate teacherDto);
    Task<TeacherDto.Response> Update(TeacherDto.RequestUpdate teacherDto);
    Task Delete(string id);
    Task<List<TeacherDto.Response>?> GetAll();
    Task<TeacherDto.Response?> GetById(string id);
}