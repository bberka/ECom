namespace ECom.Domain.Abstract.Services.Base;

public interface IAccountService<T>
{
  /// <summary>
  /// Gets user information with login request model
  /// </summary>
  /// <param name="model"></param>
  /// <returns></returns>
  CustomResult<T> Login(LoginRequest model);
  /// <summary>
  /// Changes password
  /// </summary>
  /// <param name="userId"></param>
  /// <param name="model"></param>
  /// <returns></returns>
  CustomResult ChangePassword(Guid userId, ChangePasswordRequest model);
}