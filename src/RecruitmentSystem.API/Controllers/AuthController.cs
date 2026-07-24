using Microsoft.AspNetCore.Mvc;
using RecruitmentSystem.Application.Features.Authentication.Commands.Register;
using RecruitmentSystem.Application.Features.Authentication.DTOs;
using RecruitmentSystem.Application.Features.Authentication.Services;
using Microsoft.AspNetCore.Authorization;

namespace RecruitmentSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(
    IRegisterService registerService,
    ILoginService loginService) : ControllerBase
{
    private readonly IRegisterService _registerService = registerService;
    private readonly ILoginService _loginService = loginService;

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> Register(
        [FromBody] RegisterCommand command)
    {
        var result =
            await _registerService.RegisterAsync(command);

        if (!result.Success)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequest request)
    {
        var result =
            await _loginService.LoginAsync(request);

        if (result is null)
        {
            return Unauthorized(new
            {
                message = "Invalid email or password"
            });
        }

        return Ok(result);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        return Ok(new
        {
            Message = "Token is valid",
            User = User.Identity?.Name
        });
    }
}