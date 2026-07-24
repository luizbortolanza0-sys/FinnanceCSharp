using System.Security.Claims;
using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;

public interface ITokenService
{
  string GenerateToken(User user);

  ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);

  bool ValidateToken(string token);
}