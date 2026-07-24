using Microsoft.AspNetCore.Mvc;

namespace Finnance.Controllers;

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