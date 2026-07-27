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
    var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
      Subject = new ClaimsIdentity(new Claim[]
      {
        new (ClaimTypes.NameIdentifier, user.Id.ToString()),
        new (ClaimTypes.Name, user.Username),
        new (ClaimTypes.Email, user.Email.Value),
        new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())

      }),
      Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes),
      SigningCredentials =
      new SigningCredentials(new SymmetricSecurityKey(key),
      SecurityAlgorithms.HmacSha256Signature),
      Issuer = _jwtSettings.Issuer,
      Audience = _jwtSettings.Audience

    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
  }

  public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
  {
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.UTF8.GetBytes(_jwtSettings.Key);

    var validationParameters = new TokenValidationParameters
    {
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(key),

      ValidateIssuer = true,
      ValidIssuer = _jwtSettings.Issuer,

      ValidateAudience = true,
      ValidAudience = _jwtSettings.Audience,

      ValidateLifetime = false
    };

    var principal = tokenHandler.ValidateToken(
        token,
        validationParameters,
        out SecurityToken validatedToken);

    if (validatedToken is not JwtSecurityToken jwtToken)
      throw new SecurityTokenException("Token inválido.");

    if (!jwtToken.Header.Alg.Equals(
            SecurityAlgorithms.HmacSha256,
            StringComparison.OrdinalIgnoreCase))
    {
      throw new SecurityTokenException("Algoritmo inválido.");
    }

    return principal;
  }
}