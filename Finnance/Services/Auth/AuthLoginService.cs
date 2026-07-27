using Finnance.DTOs.Auth;
using Finnance.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finnance.Services.Auth;

public class LoginService
{
  private readonly IUserRepository _userRepository;
  private readonly IPasswordHasher _passwordHasher;
  private readonly ITokenService _tokenService;
  private readonly IRefreshTokenService _refreshTokenService;
  private readonly IRefreshTokenRepository _refreshTokenRepository;

  public LoginService(
      IUserRepository userRepository,
      IPasswordHasher passwordHasher,
      ITokenService tokenService,
      IRefreshTokenService refreshTokenService,
      IRefreshTokenRepository refreshTokenRepository)
  {
    _userRepository = userRepository;
    _passwordHasher = passwordHasher;
    _tokenService = tokenService;
    _refreshTokenService = refreshTokenService;
    _refreshTokenRepository = refreshTokenRepository;
  }

  public async Task<PostLoginResponseDto> LoginAsync(PostLoginDto dto)
  {
    var user = await _userRepository.GetUserByUsernameAsync(dto.Login);

    if (user is null)
      throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

    if (!_passwordHasher.Verify(user.PasswordHash, dto.Password))
      throw new UnauthorizedAccessException("Usuário ou senha inválidos.");

    var refreshToken = await _refreshTokenService.CreateAsync(user);

    await _refreshTokenRepository.SaveAsync(refreshToken);

    return new PostLoginResponseDto
    {
      Token = _tokenService.GenerateToken(user),
      RefreshToken = refreshToken.Token
    };
  }
}
