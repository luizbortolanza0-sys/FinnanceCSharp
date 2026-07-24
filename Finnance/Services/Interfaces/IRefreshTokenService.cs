using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;

public interface IRefreshTokenService
{
  Task<RefreshToken> CreateAsync(User user);
  Task<bool> ValidateAsync(string token);
  Task<RefreshToken> RotateAsync(string token);
}