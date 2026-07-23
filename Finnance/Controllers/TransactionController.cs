using Microsoft.AspNetCore.Mvc;

namespace Finnance.Controllers;

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