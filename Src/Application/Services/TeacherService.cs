using Application.DTOs;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;

namespace Application.Services;

public class TeacherService : ITeacherService
{
    private readonly IRepository _repository;

    public TeacherService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<TeacherDto.Response?> Create(TeacherDto.RequestCreate teacherDto)
    {
        var emailValue = Email.Create(teacherDto.email);
        var dniValue = Dni.Create(teacherDto.dni);
        if (string.IsNullOrEmpty(emailValue.Value) || string.IsNullOrEmpty(dniValue.Value))
            throw new FormatInvalidException("Email inválido");
        var teacherFound =
            await _repository.GetTheFirstOne<Teacher>(t =>
                t.Email.Equals(emailValue.Value) || t.Dni.Equals(dniValue.Value));
        if (teacherFound != null) throw new BusinessConflictException("El nuevo profesor ya está registrado.");
        var newTeacher = new Teacher(teacherDto.firstName, teacherDto.lastName, emailValue, dniValue, teacherDto.age,
            new Domicilie(teacherDto.city, teacherDto.street, teacherDto.number), teacherDto.phone,
            new User(teacherDto.userName, teacherDto.password));
        await _repository.Add<Teacher>(teacherFound);
        return new TeacherDto.Response();
    }

    public async Task<TeacherDto.Response> Update(TeacherDto.RequestUpdate teacherDto)
    {
        var emailValue = Email.Create(teacherDto.email);
        var dniValue = Dni.Create(teacherDto.dni);
        if (string.IsNullOrEmpty(emailValue.Value) || string.IsNullOrEmpty(dniValue.Value))
            throw new FormatInvalidException("Email inválido");
        var teacherFound =
            await _repository.GetTheFirstOne<Teacher>(t =>
                t.Email.Equals(emailValue.Value) || t.Dni.Equals(dniValue.Value));
        if (teacherFound == null)
            throw new EntityNotFoundException($"El profesor de id {teacherDto.id} no se encontró.");
        await _repository.Add(teacherFound);
        return new TeacherDto.Response();
    }

    public async Task Delete(string id)
    {
        if (!Guid.TryParse(id, out var teacherId))
            throw new BusinessConflictException("El id tiene un formato inválido.");
        var teacherFound = await _repository.GetForId<Teacher>(teacherId);
        if (teacherFound == null) throw new EntityNotFoundException($"El profesor de id {id} no se encontró.");
        await _repository.Delete(teacherFound);
    }

    public async Task<List<TeacherDto.Response>?> GetAll()
    {
        var teachers = await _repository.GetAll<Teacher>();
        if (teachers.Count() <= 0) return [];
        return teachers.Select(t => new TeacherDto.Response()).ToList();
    }

    public async Task<TeacherDto.Response?> GetById(string id)
    {
        if (!Guid.TryParse(id, out var teacherId))
            throw new BusinessConflictException("El id tiene un formato inválido.");
        var teacherFound = await _repository.GetForId<Teacher>(teacherId);
        if (teacherFound == null) throw new EntityNotFoundException($"El profesor de id {id} no se encontró.");
        return new TeacherDto.Response();
    }
}