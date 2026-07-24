namespace Finnance;

public class JwtSettings
{
  public string Key { get; set; } = string.Empty;
  public string Issuer { get; set; } = "Finnance";
  public string Audience { get; set; } = "Finnance";
  public int ExpirationMinutes { get; set; } = 10;
}