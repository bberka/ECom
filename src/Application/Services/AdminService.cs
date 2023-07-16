using ECom.Domain;
using ECom.Domain.DTOs.AdminDTOs;
using ECom.Domain.Entities;

namespace ECom.Application.Services;

public class AdminService : IAdminService
{
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidationService _validationService;

  public AdminService(
    IUnitOfWork unitOfWork,
    IOptionService optionService,
    IValidationService validationService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _validationService = validationService;
  }


  public CustomResult<Admin> GetAdmin(string email) {
    var admin = _unitOfWork.AdminRepository
      .Get(x => x.EmailAddress == email && !x.DeletedDate.HasValue && x.IsValid == true)
      .Include(x => x.Role)
      .FirstOrDefault();
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.IsValid == false) return DomainResult.Invalid(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Deleted(nameof(Admin));
    //if (admin.Role.Permissions.Count == 0) return DomainResult.Admin.NotHavePermission();
    return admin;
  }

  public CustomResult<AdminDto> GetAdminDto(int id) {
    var adminQuery = _unitOfWork.AdminRepository
      .Get(x => x.Id == id)
      .Select(x => new AdminDto {
        EmailAddress = x.EmailAddress,
        Permissions = x.Role.PermissionRoles.Select(y => y.Permission.Name).ToArray(),
        RoleId = x.RoleId,
        RoleName = x.Role.Name,
        TwoFactorType = x.TwoFactorType,
        Id = x.Id,
        Password = x.Password,
        IsValid = x.IsValid,
        DeletedDate = x.DeletedDate,
      })
      .FirstOrDefault();
    if (adminQuery is null) return DomainResult.NotFound(nameof(Admin));
    if (adminQuery.IsValid == false) return DomainResult.Invalid(nameof(Admin));
    if (adminQuery.DeletedDate.HasValue) return DomainResult.Deleted(nameof(Admin));
    return adminQuery;
  }

  public CustomResult<AdminDto> GetAdminDto(string email) {
    var adminQuery = _unitOfWork.AdminRepository
      .Get(x => x.EmailAddress == email)
      .Select(x => new AdminDto {
        EmailAddress = x.EmailAddress,
        Permissions = x.Role.PermissionRoles.Select(y => y.Permission.Name).ToArray(),
        RoleId = x.RoleId,
        RoleName = x.Role.Name,
        TwoFactorType = x.TwoFactorType,
        Id = x.Id,
        Password = x.Password,
        IsValid = x.IsValid,
        DeletedDate = x.DeletedDate,
      })
      .FirstOrDefault();
    if (adminQuery is null) return DomainResult.NotFound(nameof(Admin));
    if (adminQuery.IsValid == false) return DomainResult.Invalid(nameof(Admin));
    if (adminQuery.DeletedDate.HasValue) return DomainResult.Deleted(nameof(Admin));
    return adminQuery;
  }

  public CustomResult<Admin> GetAdmin(int id) {
    var admin = _unitOfWork.AdminRepository.Get(x => x.Id == id && !x.DeletedDate.HasValue && x.IsValid == true)
      .Include(x => x.Role)
      .FirstOrDefault();
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.IsValid == false) return DomainResult.Invalid(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Deleted(nameof(Admin));
    return admin;
  }

  public CustomResult<AdminDto> AdminLogin(LoginRequest model) {
    var adminResult = GetAdminDto(model.EmailAddress);
    if (!adminResult.Status) return adminResult;
    var admin = adminResult.Data!;
    if (!admin.Password.Equals(model.EncryptedPassword,StringComparison.Ordinal)) return DomainResult.NotFound("Account");
    if (admin.Permissions.Length == 0) return DomainResult.None(nameof(Permission));
    if (admin.TwoFactorType != 0) {
      //TODO: two factor authentication
    }
    return admin;
  }

  public bool IsValidAdminAccount(int id) {
    return _unitOfWork.AdminRepository.Any(x => x.Id == id && !x.DeletedDate.HasValue && x.IsValid == true);
  }

  public bool AdminExists(int id) {
    return _unitOfWork.AdminRepository.Any(x => x.Id == id);
  }

  public bool AdminExists(string email) {
    return _unitOfWork.AdminRepository.Any(x => x.EmailAddress == email);
  }

  public List<Admin> GetAdmins() {
    return _unitOfWork.AdminRepository.Get().ToList();
  }

  public CustomResult AddAdmin(AddAdminRequest admin) {
    _unitOfWork.AdminRepository.Insert(admin.ToAdminEntity());
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAdmin));
    return DomainResult.OkAdded(nameof(Admin));
  }

  public int GetAdminRoleId(int adminId) {
    return _unitOfWork.AdminRepository
      .Get(x => x.Id == adminId && x.IsValid == true && !x.DeletedDate.HasValue)
      .Select(x => x.RoleId)
      .FirstOrDefault(0);
  }


  public CustomResult ChangePassword(ChangePasswordRequest model) {
    var admin = _unitOfWork.AdminRepository.GetById(model.AuthenticatedAdminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.Password != model.EncryptedOldPassword) return DomainResult.WrongPassword();
    admin.Password = model.EncryptedNewPassword;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(ChangePassword));
    return DomainResult.OkUpdated("Password");
  }



  public List<Permission> GetValidPermissions() {
    return _unitOfWork.PermissionRepository.Get(x => x.IsValid == true).ToList();
  }

  public List<Permission> GetInvalidPermissions() {
    return _unitOfWork.PermissionRepository.Get(x => x.IsValid == false).ToList();
  }

  public bool IsValidPermission(int permissionId) {
    return _unitOfWork.PermissionRepository.Any(x => x.IsValid == true && x.Id == permissionId);
  }

  public List<Admin> ListOtherAdmins(int adminId) {
    return _unitOfWork.AdminRepository
      .Get(x => x.Id != adminId)
      .Include(x => x.Role)
      .ToList();
  }

  public CustomResult EnableAdmin(int authorAdminId, int adminId) {
    //TODO: maybe check admin permissions here as well
    var admin = _unitOfWork.AdminRepository.GetById(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    admin.IsValid = !admin.IsValid;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(EnableAdmin));
    return DomainResult.OkUpdated(nameof(Admin));
  }

  public CustomResult DisableAdmin(int authorAdminId, int adminId) {
    //TODO: maybe check admin permissions here as well
    var admin = _unitOfWork.AdminRepository.GetById(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    admin.IsValid = !admin.IsValid;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DisableAdmin));
    return DomainResult.OkUpdated(nameof(Admin));
  }

  public CustomResult DeleteAdmin(int authorAdminId, int adminId) {
    var admin = _unitOfWork.AdminRepository.GetById(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Deleted(nameof(Admin));
    admin.DeletedDate = DateTime.Now;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAdmin));
    return DomainResult.OkDeleted(nameof(Admin));
  }
}