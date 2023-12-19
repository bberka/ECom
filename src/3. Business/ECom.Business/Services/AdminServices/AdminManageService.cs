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
    if (!roleExist) return DefResult.NotFound("role");
    var exists = _unitOfWork.Admins.Any(x => x.EmailAddress == request.EmailAddress);
    if (exists) return DefResult.AlreadyExists("email_address");
    var dbAdmin = request.FromRequestAddAdmin();
    _unitOfWork.Admins.Add(dbAdmin);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddAdmin));
    return DefResult.OkAdded(nameof(Admin));
  }

  public Result UpdateAnotherAdmin(Guid requesterAdminId, Request_Admin_Update request) {
    requesterAdminId.EnsureNotNull();
    request.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var isSelf = requesterAdminId.Equals(request.Id);
    if (isSelf) return DefResult.Invalid(nameof(Admin));
    var admin = _unitOfWork.Admins.Find(request.Id);
    if (admin is null) return DefResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DefResult.Invalid(nameof(Admin));
    var isAllSame = admin.EmailAddress == request.EmailAddress && admin.RoleId == request.RoleId;
    //if (request.UpdatePassword && !string.IsNullOrEmpty(request.Password)) {
    //  var tempPass = admin.Password;
    //  admin.Password = request.Password.ToHashedText();
    //  isAllSame = isAllSame && admin.Password == tempPass;
    //}
    if (isAllSame) return DefResult.OkNotChanged(nameof(Admin));
    if (admin.EmailAddress != request.EmailAddress) {
      var exists = _unitOfWork.Admins.Any(x => x.EmailAddress == request.EmailAddress);
      if (exists) return DefResult.AlreadyExists("email_address");
      admin.EmailAddress = request.EmailAddress;
    }

    var roleExist = _roleService.RoleExists(request.RoleId);
    if (!roleExist) return DefResult.NotFound(Role.LocKey);

    admin.RoleId = request.RoleId;
    admin.UpdateDate = DateTime.UtcNow;

    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(UpdateAnotherAdmin));
    return DefResult.OkUpdated(nameof(Admin));
  }

  public Result RecoverAdmin(Guid requesterAdminId, Guid id) {
    requesterAdminId.EnsureNotNull();
    id.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var isSelf = requesterAdminId.Equals(id);
    if (isSelf) return DefResult.Invalid(nameof(Admin));
    var admin = _unitOfWork.Admins.Find(id);
    if (admin is null) return DefResult.NotFound(nameof(Admin));
    if (!admin.DeleteDate.HasValue) return DefResult.NotDeleted(nameof(Admin));
    admin.DeleteDate = null;
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(RecoverAdmin));
    return DefResult.OkRecovered(nameof(Admin));
  }

  public Result DeleteAdmin(Guid requesterAdminId, Guid id) {
    requesterAdminId.EnsureNotNull();
    id.EnsureNotNull();
    _roleService.EnsurePermission(requesterAdminId, AdminPermissionType.ManageAdmins);
    var isSelf = requesterAdminId.Equals(id);
    if (isSelf) return DefResult.Invalid(nameof(Admin));
    var admin = _unitOfWork.Admins.Find(id);
    if (admin is null) return DefResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DefResult.AlreadyDeleted(nameof(Admin));
    admin.DeleteDate = DateTime.Now;
    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteAdmin));
    return DefResult.OkDeleted(nameof(Admin));
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
    if (isSelf) return DefResult.Invalid(nameof(Admin));
    var isEquals = requesterAdminId.Equals(id);
    if (isEquals) return DefResult.Invalid(nameof(Admin));
    var admin = _unitOfWork.Admins.FirstOrDefault(x => x.Id == id && !x.DeleteDate.HasValue);
    if (admin is null) return DefResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DefResult.Invalid(nameof(Admin));
    var newPassword = EasGenerate.RandomString(12);
    admin.Password = newPassword.ToHashedText();
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.Admins.Update(admin);
    var result = _unitOfWork.Save();
    if (!result) return DefResult.DbInternalError(nameof(ResetPassword));
    return newPassword;
  }
}