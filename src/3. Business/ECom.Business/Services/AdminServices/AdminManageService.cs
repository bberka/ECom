using ECom.Foundation.Static;

namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminManageService : IAdminManageService
{
  private readonly IAdminRoleService _roleService;
  private readonly IUnitOfWork _unitOfWork;

  public AdminManageService(IUnitOfWork unitOfWork, IAdminRoleService roleService) {
    _unitOfWork = unitOfWork;
    _roleService = roleService;
  }

  public Result AddAdmin(Guid requesterAdminId, Request_Admin_Add request) {
    requesterAdminId.EnsureNotNull();
    request.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var roleExist = _roleService.RoleExists(request.RoleId);
    if (!roleExist) return DomResults.x_is_not_found("role");
    var exists = _unitOfWork.Admins.Any(x => x.EmailAddress == request.EmailAddress);
    if (exists) return DomResults.x_already_exists("email_address");
    var dbAdmin = request.FromRequestAddAdmin();
    _unitOfWork.Admins.Add(dbAdmin);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(AddAdmin));
    return DomResults.x_is_added_successfully("admin");
  }

  public Result UpdateAnotherAdmin(Guid requesterAdminId, Request_Admin_Update request) {
    requesterAdminId.EnsureNotNull();
    request.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var isSelf = requesterAdminId.Equals(request.Id);
    if (isSelf) return DomResults.x_is_invalid("admin");
    var admin = _unitOfWork.Admins.Find(request.Id);
    if (admin is null) return DomResults.x_is_not_found("admin");
    if (admin.DeleteDate.HasValue) return DomResults.x_is_invalid("admin");
    var isAllSame = admin.EmailAddress == request.EmailAddress && admin.RoleId == request.RoleId;
    //if (request.UpdatePassword && !string.IsNullOrEmpty(request.Password)) {
    //  var tempPass = admin.Password;
    //  admin.Password = request.Password.ToHashedText();
    //  isAllSame = isAllSame && admin.Password == tempPass;
    //}
    if (isAllSame) return DomResults.success_not_changed("admin");
    if (admin.EmailAddress != request.EmailAddress) {
      var exists = _unitOfWork.Admins.Any(x => x.EmailAddress == request.EmailAddress);
      if (exists) return DomResults.x_already_exists("email_address");
      admin.EmailAddress = request.EmailAddress;
    }

    var roleExist = _roleService.RoleExists(request.RoleId);
    if (!roleExist) return DomResults.x_is_not_found("role");

    admin.RoleId = request.RoleId;
    admin.UpdateDate = DateTime.UtcNow;

    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(UpdateAnotherAdmin));
    return DomResults.x_is_updated_successfully("admin");
  }

  public Result RecoverAdmin(Guid requesterAdminId, Guid id) {
    requesterAdminId.EnsureNotNull();
    id.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var isSelf = requesterAdminId.Equals(id);
    if (isSelf) return DomResults.x_is_invalid("admin");
    var admin = _unitOfWork.Admins.Find(id);
    if (admin is null || !admin.DeleteDate.HasValue) return DomResults.x_is_not_found("admin");
    admin.DeleteDate = null;
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(RecoverAdmin));
    return DomResults.x_is_recovered_successfully("admin");
  }

  public Result DeleteAdmin(Guid requesterAdminId, Guid id) {
    requesterAdminId.EnsureNotNull();
    id.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var isSelf = requesterAdminId.Equals(id);
    if (isSelf) return DomResults.x_is_invalid("admin");
    var admin = _unitOfWork.Admins.Find(id);
    if (admin is null) return DomResults.x_is_not_found("admin");
    if (admin.DeleteDate.HasValue) return DomResults.x_already_deleted("admin");
    admin.DeleteDate = DateTime.Now;
    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomResults.db_internal_error(nameof(DeleteAdmin));
    return DomResults.x_is_deleted_successfully("admin");
  }


  public List<AdminDto> GetAdminList(Guid requesterAdminId) {
    requesterAdminId.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    return _unitOfWork.Admins.Where(x => x.Id != requesterAdminId)
                      .Include(x => x.Role)
                      .Select(x => x.ToDto())
                      .ToList();
  }

  public Result<string> ResetPassword(Guid requesterAdminId, Guid id) {
    requesterAdminId.EnsureNotNull();
    id.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var isSelf = requesterAdminId.Equals(id);
    if (isSelf) return DomResults.x_is_invalid("admin");
    var isEquals = requesterAdminId.Equals(id);
    if (isEquals) return DomResults.x_is_invalid("admin");
    var admin = _unitOfWork.Admins.FirstOrDefault(x => x.Id == id && !x.DeleteDate.HasValue);
    if (admin is null) return DomResults.x_is_not_found("admin");
    if (admin.DeleteDate.HasValue) return DomResults.x_is_invalid("admin");
    var newPassword = EasGenerate.RandomString(12);
    admin.Password = newPassword.ToHashedText();
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.Admins.Update(admin);
    var result = _unitOfWork.Save();
    if (!result) return DomResults.db_internal_error(nameof(ResetPassword));
    return newPassword;
  }
}