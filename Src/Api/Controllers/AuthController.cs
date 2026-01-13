using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] UserDto.Request user)
    {
        var userAuthenticated = await _authService.Login(user);
        if(userAuthenticated == null) return BadRequest("Hubo un error al autenticar al usuario.");
        return Ok(new
        {
            Message = "Usuario autenticado con éxito.",
            User =  userAuthenticated
        });
    }
}