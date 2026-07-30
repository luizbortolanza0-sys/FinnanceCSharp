using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;

public interface IRefreshTokenRepository
{
  public Task<RefreshToken?> GetRefreshTokenAsync(Guid userId);
  public Task SaveAsync(RefreshToken token);
}