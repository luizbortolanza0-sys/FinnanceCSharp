using Finnance.Models.ValueObjects;

namespace Finnance.Models.Entities;

/*
User
- Id (Guid)
- Name (Varchar (80))
- Email (Varchar (80))
- PasswordHash (Varchar(255))
- CreatedAt DateTime
- UpdatedAt DateTime
- DeletedAt DateTime
- IsActive Boolean
*/

public class User
{
  public Guid Id { get; private set; }
  public string Username { get; private set; } = null!;
  public Email Email { get; private set; } = null!;
  public string PasswordHash { get; private set; } = null!;
  public DateTime CreatedAt { get; private set; }
  public DateTime? UpdatedAt { get; private set; }
  public DateTime? DeletedAt { get; private set; }
  public bool IsActive { get; private set; }

  // Necessario no EF core!
  private User() { }
  private User(string username, Email email, string password)
  {
    Id = Guid.NewGuid();
    Username = username;
    Email = email;
    PasswordHash = password;
    CreatedAt = DateTime.UtcNow;
    IsActive = true;
  }

  static public User Create(string username, string email, string password)
  {
    if (string.IsNullOrWhiteSpace(username))
      throw new ArgumentException("O username é obrigatorio!");

    if (string.IsNullOrWhiteSpace(password))
      throw new ArgumentException("Senha é obrigatoria!");

    var emailValido = new Email(email);

    return new User(username, emailValido, password);
  }

}