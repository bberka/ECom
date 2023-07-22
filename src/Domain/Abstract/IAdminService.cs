using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IAdminService
{
  /// <summary>
  /// Gets admin information with login request model
  /// </summary>
  /// <param name="model"></param>
  /// <returns></returns>
  CustomResult<AdminDto> AdminLogin(LoginRequest model);

  /// <summary>
  /// Returns a list of admins except the requester admin
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <returns></returns>
  List<AdminDto> GetAdminList(Guid requesterAdminId);

  //
  /// <summary>
  /// Resets password by other admin request and returns randomly generated password
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="adminId"></param>
  /// <returns></returns>
  CustomResult<string> ResetPassword(Guid requesterAdminId, Guid adminId);

  /// <summary>
  /// Changes password by email token 
  /// </summary>
  /// <param name="token"></param>
  /// <returns></returns>
  CustomResult<string> ResetPassword(ResetPasswordByTokenRequest token);

  /// <summary>
  /// Changes password by another admin
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="model"></param>
  /// <returns></returns>
  CustomResult ChangePassword(Guid requesterAdminId, ChangePasswordRequest model);

  /// <summary>
  /// Adds new admin account to admin panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="admin"></param>
  /// <returns></returns>
  CustomResult AddAdmin(Guid requesterAdminId, AddAdminRequest admin);

  /// <summary>
  /// Updates an admin account for panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  CustomResult UpdateAdmin(Guid requesterAdminId, UpdateAdminAccountRequest request);

  /// <summary>
  /// Soft deletes an admin account by doing so disables the panel access however this wont have affect till admin re-logins.
  /// Account can be recovered later 
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="userId"></param>
  /// <returns></returns>
  CustomResult DeleteAdmin(Guid requesterAdminId, Guid userId);

  /// <summary>
  /// Recovers a deleted admin account by doing so enables the panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="id"></param>
  /// <returns></returns>
  CustomResult RecoverAdmin(Guid requesterAdminId, Guid id);
}