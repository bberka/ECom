using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminManageService
{
  /// <summary>
  ///   Returns a list of admins except the requester admin
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <returns></returns>
  List<AdminDto> GetAdminList(Guid requesterAdminId);


  /// <summary>
  ///   Resets password by other admin request and returns randomly generated password
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="adminId"></param>
  /// <returns></returns>
  Result<string> ResetPassword(Guid requesterAdminId, Guid adminId);


  /// <summary>
  ///   Adds new admin account to admin panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="requestAdmin"></param>
  /// <returns></returns>
  Result AddAdmin(Guid requesterAdminId, Request_Admin_Add requestAdmin);

  /// <summary>
  ///   Updates an admin account for panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  Result UpdateAdmin(Guid requesterAdminId, Request_Admin_UpdateAccount request);

  /// <summary>
  ///   Soft deletes an admin account by doing so disables the panel access however this wont have affect till admin
  ///   re-logins.
  ///   Account can be recovered later
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="userId"></param>
  /// <returns></returns>
  Result DeleteAdmin(Guid requesterAdminId, Guid userId);

  /// <summary>
  ///   Recovers a deleted admin account by doing so enables the panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="id"></param>
  /// <returns></returns>
  Result RecoverAdmin(Guid requesterAdminId, Guid id);
}