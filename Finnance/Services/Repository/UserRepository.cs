using Finnance.Data;
using Finnance.Models.Entities;
using Finnance.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Finnance.Services.Repository;

public class UserRepository : IUserRepository
{
  private readonly FinnanceDataContext _context;

  public UserRepository(FinnanceDataContext context)
  {
    _context = context;
  }

  public async Task AddAsync(User user)
  {
    await _context.Users.AddAsync(user);
    await _context.SaveChangesAsync();
  }

  public async Task<User?> GetUserByEmailAsync(string email)
  {
    return await _context.Users.
      AsNoTracking().
      FirstOrDefaultAsync(u => u.Email.Value == email);
  }

  public async Task<User?> GetUserByIdAsync(Guid userId)
  {
    return await _context.Users.
      AsNoTracking().
      FirstOrDefaultAsync(u => u.Id == userId);
  }

  public async Task<User?> GetUserByUsernameAsync(string username)
  {
    return await _context.Users.
      AsNoTracking().
      FirstOrDefaultAsync(u => u.Username == username);
  }
}
