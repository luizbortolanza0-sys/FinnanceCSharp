using System.Text.RegularExpressions;

namespace Finnance.Domain.ValueObjects;

public sealed class Email
{
  private static readonly Regex EmailRegex = new(
      @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
      RegexOptions.Compiled);

  public string Value { get; private set; }

  // Necessario no EF core!
  private Email()
  {
  }
  public Email(string value)
  {
    if (string.IsNullOrWhiteSpace(value))
      throw new ArgumentException("E-mail é obrigatório.");

    if (!EmailRegex.IsMatch(value))
      throw new ArgumentException("E-mail inválido.");

    Value = value;
  }

  public override string ToString() => Value;

  public static implicit operator string(Email email) => email.Value;
}