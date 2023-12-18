using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Abstract.Services.Base;

public interface IAccountService<T>
{
  /// <summary>
  ///   Changes password
  /// </summary>
  /// <param name="userId"></param>
  /// <param name="model"></param>
  /// <returns></returns>
  Result ChangePassword(Guid userId, Request_Password_Change model);
}