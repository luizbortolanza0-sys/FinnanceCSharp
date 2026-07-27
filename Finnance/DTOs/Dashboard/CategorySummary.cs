namespace Finnance.DTOs.Dashboard;

public class CategorySummary
{
  public string Category { get; init; } = "";
  public int Count { get; init; }
  public decimal Total { get; init; }
}