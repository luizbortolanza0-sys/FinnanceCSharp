namespace Finnance.Models.Entities;

/*
RefreshToken
------------
- Id         (int, PK, AutoIncrement)
- Token      (string)
- UserId     (Guid, FK -> User.Id)
- User       (Navigation Property)
- ExpiresAt  (DateTime)
- RevokedAt  (DateTime?)
- CreatedAt  (DateTime)
*/
public class RefreshToken
{
  public int Id { get; private set; }
  public string Token { get; private set; } = null!;
  public User User { get; private set; } = null!;
  public Guid UserId { get; private set; }
  public DateTime ExpiresAt { get; private set; }
  public DateTime? RevokedAt { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public bool IsExpired =>
    DateTime.UtcNow >= ExpiresAt;
  public bool IsRevoked =>
      RevokedAt != null;
  public bool IsActive =>
      !IsExpired && !IsRevoked;
  private RefreshToken() { }

  private RefreshToken(string token, User user, DateTime expiresAt)
  {
    Token = token;
    User = user;
    UserId = user.Id;
    ExpiresAt = expiresAt;
    CreatedAt = DateTime.UtcNow;
  }
  public static RefreshToken Create(string token, User user, DateTime expiresAt)
  {
    if (!user.IsActive)
      throw new InvalidOperationException("Usuario esta inativo.");

    if (string.IsNullOrWhiteSpace(token))
      throw new ArgumentException("Token invalido");

    if (expiresAt <= DateTime.UtcNow)
      throw new ArgumentException("A data de expiração deve ser futura.");

    return new RefreshToken(token, user, expiresAt);
  }
  public void Revoke()
  {
    if (IsRevoked)
      return;

    RevokedAt = DateTime.UtcNow;
  }
}