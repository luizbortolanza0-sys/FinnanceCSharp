using Finnance.DTOs.Dashboard;

public class DashboardDto
{
  public decimal TotalIncome { get; set; }
  public decimal TotalExpense { get; set; }
  public decimal Balance { get; set; }

  public List<CategorySummary> Categories { get; set; } = [];
  public List<MonthlySummary> Monthly { get; set; } = [];
}