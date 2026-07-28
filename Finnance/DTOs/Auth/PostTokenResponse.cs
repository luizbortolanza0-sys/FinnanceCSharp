namespace Finnance.DTOs.Auth;

public class PostTokenResponse
{
  public string Token { get; set; } = "";
  public string RefreshToken { get; set; } = "";
}