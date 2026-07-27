using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finnance.Controllers;

[Authorize]
[ApiController]
[Route("dashboard")]
public class DashboardController : ControllerBase
{
  [HttpGet]
  [Route("teste")]
  public string GetTeste()
  {
    return "Teste";
  }
}