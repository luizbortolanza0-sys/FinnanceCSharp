namespace Finnance.DTOs.Auth;

public class PostLoginResponseDto
{
  public string Token { get; set; } = "";
  public string RefreshToken { get; set; } = "";
}