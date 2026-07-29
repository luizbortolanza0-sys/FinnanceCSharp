using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;
//Falta implementar

public interface IRefreshTokenRepository
{
  public Task<RefreshToken> GetRefreshTokenAsync(Guid userId);
  public Task<bool> SaveAsync(RefreshToken token);
}