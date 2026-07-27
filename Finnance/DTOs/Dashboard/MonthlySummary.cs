namespace Finnance.DTOs.Dashboard;

public class MonthlySummary
{
  public int Year { get; set; }
  public int Month { get; set; }
  public decimal Income { get; set; }
  public decimal Expense { get; set; }
  public decimal Total { get; set; }
}