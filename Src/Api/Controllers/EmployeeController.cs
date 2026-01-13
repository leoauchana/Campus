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
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAll();
            if (employees == null) return BadRequest("Hubo un error al obtener los profesores.");
            return Ok(new
            {
                Message = "Profesores registrados",
                Employees = employees
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] EmployeeDto.Request newEmployee)
        {
            var employeeRegistered = await _employeeService.Create(newEmployee);
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
            var employeeFound = await _employeeService.GetById(id);
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
            await _employeeService.Delete(id);
            return Ok("Profesor eliminado con éxito.");
        }
    }
}