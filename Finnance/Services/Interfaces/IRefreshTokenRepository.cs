using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;
//Falta implementar

public interface IRefreshTokenRepository
{
  Task<RefreshToken> GetRefreshTokenAsync(Guid userId);
  Task<bool> SaveAsync(RefreshToken token);
}