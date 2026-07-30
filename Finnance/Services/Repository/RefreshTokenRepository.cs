using Finnance.Data;
using Finnance.Models.Entities;
using Finnance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finnance.Services.Repository;

public class RefreshTokenRepository : IRefreshTokenRepository
{
  private readonly FinnanceDataContext _context;

  public RefreshTokenRepository(FinnanceDataContext context)
  {
    _context = context;
  }
  public async Task<RefreshToken?> GetRefreshTokenAsync(Guid userId)
  {
    return await _context.RefreshTokens.
      AsNoTracking().
      FirstOrDefaultAsync(r => r.UserId == userId);
  }

  public async Task SaveAsync(RefreshToken token)
  {
    await _context.RefreshTokens.AddAsync(token);
    await _context.SaveChangesAsync();
  }
}