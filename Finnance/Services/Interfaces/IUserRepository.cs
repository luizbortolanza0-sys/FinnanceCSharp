using Finnance.Models.Entities;

namespace Finnance.Services.Interfaces;
//Falta implementar

public interface IUserRepository
{
  public Task<User?> GetUserByIdAsync(Guid userId);
  public Task<User?> GetUserByUsernameAsync(string username);
  public Task<User?> GetUserByEmailAsync(string email);
  public Task AddAsync(User user);

}