using Finnance.DTOs.Auth;
using Finnance.Models.Entities;
using Finnance.Services.Interfaces;

namespace Finnance.Services.Auth;

public class AuthRegisterService
{
  private readonly IUserRepository _userRepository;
  private readonly IPasswordHasher _passwordHasher;
  private readonly ITokenService _tokenService;
  private readonly IRefreshTokenService _refreshTokenService;
  public AuthRegisterService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenService tokenService,
    IRefreshTokenService refreshTokenService)
  {
    _userRepository = userRepository;
    _passwordHasher = passwordHasher;
    _tokenService = tokenService;
    _refreshTokenService = refreshTokenService;
  }

  public async Task<PostTokenResponse> RegisterAsync(PostRegisterDto registerUser)
  {
    var newUser = User.Create(
      registerUser.Username,
      registerUser.Email,
      _passwordHasher.Hash(registerUser.Password));
    if (!await _userRepository.AddAsync(newUser))
    {
      throw new Exception("Erro ao criar usuario, usuario existente!");
    }
    var token = _tokenService.GenerateToken(newUser);
    var refreshToken = await _refreshTokenService.CreateAsync(newUser);
    return new PostTokenResponse
    {
      Token = token,
      RefreshToken = refreshToken.Token
    };
  }
}

