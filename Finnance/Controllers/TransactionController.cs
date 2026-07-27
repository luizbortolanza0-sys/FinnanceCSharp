using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finnance.Controllers;

[Authorize]
[ApiController]
[Route("transaction")]
public class TransactionController : ControllerBase
{
  [HttpGet]
  [Route("teste")]
  public string GetTeste()
  {
    return "Teste";
  }
}