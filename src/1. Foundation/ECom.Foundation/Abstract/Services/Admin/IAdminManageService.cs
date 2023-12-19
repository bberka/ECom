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
  /// <param name="id"></param>
  /// <returns></returns>
  Result<string> ResetPassword(Guid requesterAdminId, Guid id);


  /// <summary>
  ///   Adds new admin account to admin panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  Result AddAdmin(Guid requesterAdminId, Request_Admin_Add request);

  /// <summary>
  ///   Updates an admin account for panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="request"></param>
  /// <returns></returns>
  Result UpdateAnotherAdmin(Guid requesterAdminId, Request_Admin_Update request);

  /// <summary>
  ///   Soft deletes an admin account by doing so disables the panel access however this wont have affect till admin
  ///   re-logins.
  ///   Account can be recovered later
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="id"></param>
  /// <returns></returns>
  Result DeleteAdmin(Guid requesterAdminId, Guid id);

  /// <summary>
  ///   Recovers a deleted admin account by doing so enables the panel access
  /// </summary>
  /// <param name="requesterAdminId"></param>
  /// <param name="id"></param>
  /// <returns></returns>
  Result RecoverAdmin(Guid requesterAdminId, Guid id);
}