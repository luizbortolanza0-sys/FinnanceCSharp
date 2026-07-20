namespace Finnance.Domain.ValueObjects;

public class Dinheiro
{
  public decimal Value { get; }

  public Dinheiro(decimal value)
  {
    if (value <= 0)
      throw new InvalidOperationException("O resultado não pode ser menor ou igual a zero.");

    Value = value;
  }

  public static decimal operator +(Dinheiro a, Dinheiro b) =>
    a.Value + b.Value;

  public static decimal operator -(Dinheiro a, Dinheiro b) =>
    a.Value - b.Value;

}