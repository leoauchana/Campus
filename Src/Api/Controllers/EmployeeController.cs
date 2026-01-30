using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public EmployeeController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _teacherService.GetAll();
            if (employees == null) return BadRequest("Hubo un error al obtener los profesores.");
            return Ok(new
            {
                Message = "Profesores registrados",
                Employees = employees
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TeacherDto.Request newEmployee)
        {
            var employeeRegistered = await _teacherService.Create(newEmployee);
            if (employeeRegistered == null) return BadRequest("Hubo un error al registrar al nuevo profesor");
            return Ok(new
            {
                Message = "Profesor registrado con éxito.",
                Employee = employeeRegistered
            });
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var employeeFound = await _teacherService.GetById(id);
            if (employeeFound == null) return BadRequest("Hubo un error al obtener al profesor.");
            return Ok(new
            {
                Message = "Profesor obtenido con éxito.",
                EmployeeFound = employeeFound
            });
        }

        [HttpDelete("/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _teacherService.Delete(id);
            return Ok("Profesor eliminado con éxito.");
        }
    }
}