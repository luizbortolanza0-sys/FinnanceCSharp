using Finnance.Services.Interfaces;

namespace Finnance.Services.Auth;

public class PasswordHasher : IPasswordHasher
{
  public string Hash(string password)
  {
    return BCrypt.Net.BCrypt.HashPassword(password);
  }

  public bool Verify(string passwordHash, string password)
  {
    return BCrypt.Net.BCrypt.Verify(password, passwordHash);
  }
}