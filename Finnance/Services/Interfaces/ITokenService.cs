using System.Security.Claims;
using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;

public interface ITokenService
{
  public string GenerateToken(User user);
  public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
}