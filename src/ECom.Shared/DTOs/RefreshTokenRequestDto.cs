namespace ECom.Shared.DTOs;

public class RefreshTokenRequestDto
{
  //NOTE: JWT Token is not necesseraly required here because the token is not stored only refresh token is stored

  /// <summary>
  /// Created JWT token that is given to user upon successful authentication
  /// </summary>
  [Required]
  public string Token { get; set; }

  /// <summary>
  /// Randomly generated JWT refresh token that is stored in the database with an index
  /// </summary>
  [Required]
  public string RefreshToken { get; set; }
}