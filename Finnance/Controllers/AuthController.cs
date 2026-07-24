using Finnance.DTOs.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Finnance.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
  [HttpPost]
  [Route("login")]
  public IActionResult PostLogin(/*[FromBody] PostLoginDto loginUser*/)
  {

    return Ok();
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