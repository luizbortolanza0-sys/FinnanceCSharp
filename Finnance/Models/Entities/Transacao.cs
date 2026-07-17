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
}