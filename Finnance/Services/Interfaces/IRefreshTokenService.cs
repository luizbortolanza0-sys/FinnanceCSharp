using Finnance.DTOs.Auth;
using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;
//Falta implementar

public interface IRefreshTokenService
{
  public Task<RefreshToken> CreateAsync(User user);
  public Task<bool> ValidateAsync(string token);
  public Task<PostTokenResponse> RotateAsync(string token);
  public Task<bool> RevokeTokenAsync(string token);
}