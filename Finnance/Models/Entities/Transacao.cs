using Finnance.Domain.ValueObjects;
using Finnance.Models.Enums;

namespace Finnance.Models.Entities;

/*
Transaction
-----------
- Id          (int, PK, AutoIncrement)
- UserId      (Guid, FK -> User.Id)
- Amount      (Money Value Object)
- Type        (TransactionType: Income | Expense)
- Category    (Category)
- Description (text)
- Date        (DateTime)
- CreatedAt   (DateTime)
- UpdatedAt   (DateTime)
- DeletedAt   (DateTime)
*/

public class Transacao
{
  public int Id { get; private set; }
  public User User { get; private set; }
  public Guid UserId { get; private set; }
  public TipoTransacao Type { get; private set; }
  public Categoria Category { get; private set; }
  public string Description { get; private set; }
  public Dinheiro Amount { get; private set; }
  public DateTime Date { get; private set; }
  public DateTime CreatedAt { get; private set; }
  public DateTime? UpdatedAt { get; private set; }
  public DateTime? DeletedAt { get; private set; }
  private Transacao()
  {
  }

  private Transacao
  (User user,
  TipoTransacao type,
  Categoria category,
  string description,
  Dinheiro amount,
  DateTime date)
  {
    User = user;
    UserId = user.Id;
    Type = type;
    Description = description;
    Category = category;
    Amount = amount;
    Date = date;
    CreatedAt = DateTime.UtcNow;
    UpdatedAt = null;
    DeletedAt = null;

  }
  public static Transacao Create
  (User user,
  TipoTransacao type,
  Categoria category,
  string description,
  decimal value,
  DateTime date)
  {

    if (!Enum.IsDefined(category))
      throw new ArgumentException("Categoria inválida.");

    if (!Enum.IsDefined(type))
      throw new ArgumentException("Tipo da transação é inválido.");

    if (string.IsNullOrWhiteSpace(description))
      throw new ArgumentException("A descrição é necessaria.");

    if (!user.IsActive)
      throw new ArgumentException("Usuario invalido.");

    var amount = new Dinheiro(value);

    return new Transacao(user, type, category, description, amount, date);

  }


}