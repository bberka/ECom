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

  public Result AddAdmin(Guid adminId, Request_Admin_Add requestAdmin) {
    var roleExist = _roleService.RoleExists(requestAdmin.RoleId);
    if (!roleExist) return DefResult.NotFound("role");
    var exists = _unitOfWork.Admins.Any(x => x.EmailAddress == requestAdmin.EmailAddress);
    if (exists) return DefResult.AlreadyExists("email_address");
    var dbAdmin = requestAdmin.FromRequestAddAdmin();
    _unitOfWork.Admins.Add(dbAdmin);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(AddAdmin));
    return DefResult.OkAdded(nameof(Admin));
  }

  public Result UpdateAdmin(Guid requesterAdminId, Request_Admin_UpdateAccount request) {
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
    if (!res) return DefResult.DbInternalError(nameof(UpdateAdmin));
    return DefResult.OkUpdated(nameof(Admin));
  }

  public Result RecoverAdmin(Guid requesterAdminId, Guid id) {
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

  public Result DeleteAdmin(Guid requesterAdminId, Guid adminId) {
    var admin = _unitOfWork.Admins.Find(adminId);
    if (admin is null) return DefResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DefResult.AlreadyDeleted(nameof(Admin));
    admin.DeleteDate = DateTime.Now;
    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(DeleteAdmin));
    return DefResult.OkDeleted(nameof(Admin));
  }


  public List<AdminDto> GetAdminList(Guid requesterAdminId) {
    return _unitOfWork.Admins.Where(x => x.Id != requesterAdminId)
                      .Include(x => x.Role)
                      .Select(x => x.ToDto())
                      .ToList();
  }

  public Result<string> ResetPassword(Guid requesterAdminId, Guid adminId) {
    var isEquals = requesterAdminId.Equals(adminId);
    if (isEquals) return DefResult.Invalid(nameof(Admin));
    var admin = _unitOfWork.Admins.FirstOrDefault(x => x.Id == adminId && !x.DeleteDate.HasValue);
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

  public List<AdminDto> GetAdmins() {
    return _unitOfWork.Admins.Select(x => x.ToDto()).ToList();
  }

  public string? GetAdminRoleId(Guid id) {
    return _unitOfWork.Admins.Where(x => x.Id == id && !x.DeleteDate.HasValue)
                      .Select(x => x.RoleId)
                      .FirstOrDefault();
  }

  public bool IsValidPermission(string permissionId) {
    //var tryParse = Enum.TryParse(permissionId, out AdminPermission permission);
    //if (!tryParse) return false;
    return Enum.IsDefined(typeof(AdminPermissionType), permissionId);
  }
}