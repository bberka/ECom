using ECom.Application.Services.BaseServices;
using ECom.Domain;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Entities;
using Newtonsoft.Json.Linq;

namespace ECom.Application.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminService : IAdminService
{
  protected readonly IUnitOfWork UnitOfWork;
  protected readonly IAdminRoleService RoleService;

  public AdminService(IUnitOfWork unitOfWork, IAdminRoleService roleService) {
    UnitOfWork = unitOfWork;
    RoleService = roleService;
  }
  public CustomResult AddAdmin(Guid adminId, AddAdminRequest admin) {
    var roleExist = RoleService.RoleExists(admin.RoleId);
    if (!roleExist) return DomainResult.NotFound("role");
    var exists = UnitOfWork.AdminRepository.Any(x => x.EmailAddress == admin.EmailAddress);
    if (exists) return DomainResult.AlreadyExists("email_address");
    var dbAdmin = Admin.FromDto(admin);
    UnitOfWork.AdminRepository.Add(dbAdmin);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAdmin));
    return DomainResult.OkAdded(nameof(Admin));
  }
  public CustomResult UpdateAdmin(Guid requesterAdminId, UpdateAdminAccountRequest request) {
    var admin = UnitOfWork.AdminRepository.Find(request.Id);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    var isAllSame = admin.EmailAddress == request.EmailAddress && admin.RoleId == request.RoleId;
    //if (request.UpdatePassword && !string.IsNullOrEmpty(request.Password)) {
    //  var tempPass = admin.Password;
    //  admin.Password = request.Password.ToHashedText();
    //  isAllSame = isAllSame && admin.Password == tempPass;
    //}
    if (isAllSame) return DomainResult.OkNotChanged(nameof(Admin));
    if (admin.EmailAddress != request.EmailAddress) {
      var exists = UnitOfWork.AdminRepository.Any(x => x.EmailAddress == request.EmailAddress);
      if (exists) return DomainResult.AlreadyExists("email_address");
      admin.EmailAddress = request.EmailAddress;
    }
    var roleExist = RoleService.RoleExists(request.RoleId);
    if (!roleExist) return DomainResult.NotFound(nameof(Role));

    admin.RoleId = request.RoleId;
    admin.UpdateDate = DateTime.UtcNow;

    UnitOfWork.AdminRepository.Update(admin);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAdmin));
    return DomainResult.OkUpdated(nameof(Admin));
  }

  public CustomResult RecoverAdmin(Guid requesterAdminId, Guid id) {
    var admin = UnitOfWork.AdminRepository.Find(id);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (!admin.DeleteDate.HasValue) return DomainResult.NotDeleted(nameof(Admin));
    admin.DeleteDate = null;
    admin.UpdateDate = DateTime.UtcNow;
    UnitOfWork.AdminRepository.Update(admin);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RecoverAdmin));
    return DomainResult.OkRecovered(nameof(Admin));
  }
  public CustomResult DeleteAdmin(Guid requesterAdminId, Guid adminId) {
    var admin = UnitOfWork.AdminRepository.Find(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DomainResult.AlreadyDeleted(nameof(Admin));
    admin.DeleteDate = DateTime.Now;
    UnitOfWork.AdminRepository.Update(admin);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAdmin));
    return DomainResult.OkDeleted(nameof(Admin));
  }
  public List<AdminDto> GetAdmins() {
    return UnitOfWork.AdminRepository.Select(x => Admin.ToDto(x)).ToList();
  }

  public string? GetAdminRoleId(Guid userId) {
    return Enumerable.Select(UnitOfWork.AdminRepository
        .Where(x => x.Id == userId && !x.DeleteDate.HasValue), x => x.RoleId)
      .FirstOrDefault();
  }
  public List<Permission> GetPermissions() {
    return UnitOfWork.PermissionRepository.ToList();
  }

  public List<Permission> GetInvalidPermissions() {
    return UnitOfWork.PermissionRepository.ToList();
  }

  public bool IsValidPermission(string permissionId) {
    return UnitOfWork.PermissionRepository.Any(x => x.Id == permissionId);
  }


  public List<AdminDto> GetAdminList(Guid requesterAdminId) {
    return UnitOfWork.AdminRepository.Where(x => x.Id != requesterAdminId)
      .Include(x => x.Role)
      .Select(x => Admin.ToDto(x))
      .ToList();
  }
  public CustomResult<string> ResetPassword(Guid requesterAdminId, Guid adminId) {
    var isEquals = requesterAdminId.Equals(adminId);
    if (isEquals) return DomainResult.Invalid(nameof(Admin));
    var admin = UnitOfWork.AdminRepository.FirstOrDefault(x => x.Id == adminId && !x.DeleteDate.HasValue);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    var newPassword = EasGenerate.RandomString(12);
    admin.Password = newPassword.ToHashedText();
    admin.UpdateDate = DateTime.UtcNow;
    UnitOfWork.AdminRepository.Update(admin);
    var result = UnitOfWork.Save();
    if (!result) return DomainResult.DbInternalError(nameof(ResetPassword));
    return newPassword;
  }
}