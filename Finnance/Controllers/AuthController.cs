using Finnance.DTOs.Auth;
using Finnance.Services.Auth;
using Finnance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finnance.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
  private readonly AuthLoginService _loginService;
  private readonly AuthRegisterService _registerService;
  private readonly IRefreshTokenService _refreshTokenService;
  public AuthController(
    [FromServices] AuthLoginService loginService,
    [FromServices] AuthRegisterService registerService,
    [FromServices] IRefreshTokenService refreshTokenService
    )
  {
    _loginService = loginService;
    _registerService = registerService;
    _refreshTokenService = refreshTokenService;
  }

  [HttpPost]
  [Route("login")]
  public async Task<IActionResult> PostLogin([FromBody] PostLoginDto loginUser)
  {
    if (string.IsNullOrWhiteSpace(loginUser.Login))
      return BadRequest("O nome de usuario é necessario!");

    if (string.IsNullOrWhiteSpace(loginUser.Password))
      return BadRequest("O a senha é um campo necessario!");

    try
    {
      var response = await _loginService.LoginAsync(loginUser);

      return Created("", response);
    }
    catch (UnauthorizedAccessException)
    {
      return Unauthorized("Usuário ou senha inválidos.");
    }

  }


  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> PostCreateUser([FromBody] PostRegisterDto registerUser)
  {
    if (string.IsNullOrWhiteSpace(registerUser.Username))
      return BadRequest("O nome de usuario é necessario!");

    if (string.IsNullOrWhiteSpace(registerUser.Email))
      return BadRequest("O email é necessario!");

    if (string.IsNullOrWhiteSpace(registerUser.Password))
      return BadRequest("O a senha é um campo necessario!");

    try
    {
      var response = await _registerService.RegisterAsync(registerUser);

      return Ok(response);
    }
    catch (Exception ex)
    {
      return Conflict(ex.Message);
    }


  }

  [HttpPost]
  [Route("refresh")]
  public async Task<IActionResult> PostRefreshToken([FromBody] string refreshToken)
  {
    if (!await _refreshTokenService.ValidateAsync(refreshToken))
      return BadRequest("Token invalido ou expirado!");

    try
    {
      var newTokenResponse = await _refreshTokenService.RotateAsync(refreshToken);
      return Ok(newTokenResponse);
    }
    catch (Exception ex)
    {
      return BadRequest(ex.Message);
    }

  }

  [HttpPost]
  [Route("logout")]
  public async Task<IActionResult> PostLogout([FromBody] string refreshToken)
  {
    if (!await _refreshTokenService.RevokeTokenAsync(refreshToken))
      return BadRequest("Token invalido!");

    return Ok("Logout realizado com sucesso!");
  }
}