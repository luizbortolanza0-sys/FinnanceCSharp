using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Finnance.Models.Entities;
using Finnance.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Finnance.Services.Auth;

public class TokenService : ITokenService
{

  private readonly JwtSettings _jwtSettings;

  public TokenService(IOptions<JwtSettings> options)
  {
    _jwtSettings = options.Value;
  }
  public string GenerateToken(User user)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
      SigningCredentials =
      new SigningCredentials
      (new SymmetricSecurityKey(key),
      SecurityAlgorithms.HmacSha256Signature),
      Subject = new ClaimsIdentity(new Claim[]
      {
        new ("",""),
        new ("",""),
        new ("","")

      })

    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return "teste";
  }

  public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
  {
    throw new NotImplementedException();
  }

  public bool ValidateToken(string token)
  {
    throw new NotImplementedException();
  }
}