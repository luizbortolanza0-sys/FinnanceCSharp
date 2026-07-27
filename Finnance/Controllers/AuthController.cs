using Finnance.DTOs.Auth;
using Finnance.Services.Auth;
using Finnance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finnance.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
  private readonly LoginService _loginService;

  public AuthController([FromServices] LoginService loginService)
  {
    _loginService = loginService;
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

      return Ok(response);
    }
    catch (UnauthorizedAccessException)
    {
      return Unauthorized("Usuário ou senha inválidos.");
    }

  }


  [HttpPost]
  [Route("register")]
  public IActionResult PostCreateUser()
  {

    return Ok();
  }

  [HttpPost]
  [Route("refreshToken")]
  public IActionResult PostRefreshToken()
  {
    return Ok();

  }
  [HttpPost]
  [Route("logout")]
  public IActionResult PostLogout()
  {
    return Ok();
  }
}