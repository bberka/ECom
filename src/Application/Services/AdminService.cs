using ECom.Domain;
using ECom.Domain.Aspects;
using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.AspNetCore.Components.Authorization;

namespace ECom.Application.Services;


[PerformanceLoggerAspect]
[ExceptionHandlerAspect]
public class AdminService : IAdminService
{
  private readonly IOptionService _optionService;
  private readonly IRoleService _roleService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidationService _validationService;


  public AdminService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    IValidationService validationService,
    IRoleService roleService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _validationService = validationService;
    _roleService = roleService;
  
  }



  public CustomResult<string> ResetPassword(Guid author, Guid adminId) {
    var isEquals = author.Equals(adminId);
    if (isEquals) return DomainResult.Invalid(nameof(Admin));
    var admin = _unitOfWork.AdminRepository.FirstOrDefault(x => x.Id == adminId && !x.DeleteDate.HasValue);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    var newPassword = EasGenerate.RandomString(12);
    admin.Password = newPassword.ToHashedText();
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.AdminRepository.Update(admin);
    var result = _unitOfWork.Save();
    if (!result) return DomainResult.DbInternalError(nameof(AddAdmin));
    return newPassword;
  }

  public CustomResult<string> ResetPassword(ResetPasswordByTokenRequest token) {
    throw new NotImplementedException();
  }


  public CustomResult<AdminDto> AdminLogin(LoginRequest model) {
    var admin = _unitOfWork.AdminRepository
      .Get(x => x.EmailAddress == model.EmailAddress)
      .Select(x => Admin.ToDto(x))  
      .FirstOrDefault();
    if (admin is null) return DomainResult.NoAccountFound(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    var encryptedPassword = model.IsHashed ? model.Password : model.Password.ToHashedText();
    if (!admin.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
      return DomainResult.NoAccountFound(nameof(Admin));
    if (admin.Permissions.Length == 0) return DomainResult.None(nameof(Permission));
    if (admin.TwoFactorType != 0) {
      //TODO: two factor authentication
    }

    return admin;
  }

  public CustomResult AddAdmin(Guid adminId, AddAdminRequest admin) {
    var roleExist = _roleService.RoleExists(admin.RoleId);
    if (!roleExist) return DomainResult.NotFound("role");
    var adminExist = AdminExists(admin.EmailAddress);
    if (adminExist) return DomainResult.AlreadyExists("email_address");
    var dbAdmin = Admin.FromDto(admin);
    _unitOfWork.AdminRepository.Insert(dbAdmin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAdmin));
    return DomainResult.OkAdded(nameof(Admin));
  }

  public bool IsValidAdminAccount(Guid id) {
    return _unitOfWork.AdminRepository.Any(x => x.Id == id && !x.DeleteDate.HasValue);
  }

  public bool AdminExists(Guid id) {
    return _unitOfWork.AdminRepository.Any(x => x.Id == id);
  }

  public bool AdminExists(string email) {
    return _unitOfWork.AdminRepository.Any(x => x.EmailAddress == email);
  }


  public List<AdminDto> GetAdmins() {
    return _unitOfWork.AdminRepository.GetAll().Select(x => Admin.ToDto(x)).ToList();
  }

  public string? GetAdminRoleId(Guid userId) {
    return Enumerable.Select(_unitOfWork.AdminRepository
        .Get(x => x.Id == userId && !x.DeleteDate.HasValue), x => x.RoleId)
      .FirstOrDefault();
  }


  public CustomResult ChangePassword(Guid adminId, ChangePasswordRequest model) {
    var admin = _unitOfWork.AdminRepository.Find(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    var password = model.NewPassword.ToHashedText();
    if (admin.Password != password) return DomainResult.WrongPassword();
    admin.Password = password;
    admin.UpdateDate = DateTime.UtcNow;

    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(ChangePassword));
    return DomainResult.OkUpdated("Password");
  }


  public List<Permission> GetPermissions() {
    return _unitOfWork.PermissionRepository.GetAll().ToList();
  }

  public List<Permission> GetInvalidPermissions() {
    return _unitOfWork.PermissionRepository.GetAll().ToList();
  }

  public bool IsValidPermission(string permissionId) {
    return _unitOfWork.PermissionRepository.Any(x => x.Id == permissionId);
  }


  public List<AdminDto> GetAdminList(Guid requesterAdminId) {
    return _unitOfWork.AdminRepository.Get(x => x.Id != requesterAdminId)
      .Include(x => x.Role)
      .Select(x => Admin.ToDto(x))
      .ToList();
  }


  public CustomResult DeleteAdmin(Guid requesterAdminId, Guid adminId) {
    var admin = _unitOfWork.AdminRepository.Find(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DomainResult.AlreadyDeleted(nameof(Admin));
    admin.DeleteDate = DateTime.Now;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAdmin));
    return DomainResult.OkDeleted(nameof(Admin));
  }

  public CustomResult UpdateAdmin(Guid requesterAdminId, UpdateAdminAccountRequest request) {
    var admin = _unitOfWork.AdminRepository.Find(request.Id);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeleteDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    var isAllSame = admin.EmailAddress == request.EmailAddress && admin.RoleId == request.RoleId;
    if (request.UpdatePassword && !string.IsNullOrEmpty(request.Password)) {
      var tempPass = admin.Password;
      admin.Password = request.Password.ToHashedText();
      isAllSame = isAllSame && admin.Password == tempPass;
    }

    if (isAllSame) return DomainResult.OkNotChanged(nameof(Admin));
    if (admin.EmailAddress != request.EmailAddress) {
      var adminExist = AdminExists(request.EmailAddress);
      if (adminExist) return DomainResult.AlreadyExists(nameof(Admin));
      admin.EmailAddress = request.EmailAddress;
    }

    var roleExist = _roleService.RoleExists(request.RoleId);
    if (!roleExist) return DomainResult.NotFound(nameof(Role));

    admin.RoleId = request.RoleId;
    admin.UpdateDate = DateTime.UtcNow;

    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAdmin));
    return DomainResult.OkUpdated(nameof(Admin));
  }

  public CustomResult RecoverAdmin(Guid requesterAdminId, Guid id) {
    var admin = _unitOfWork.AdminRepository.Find(id);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (!admin.DeleteDate.HasValue) return DomainResult.NotDeleted(nameof(Admin));
    admin.DeleteDate = null;
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RecoverAdmin));
    return DomainResult.OkRecovered(nameof(Admin));
  }
}