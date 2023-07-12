using ECom.Domain.DTOs.AdminDTOs;

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


  public ResultData<Admin> GetAdmin(string email) {
    var admin = _unitOfWork.AdminRepository
      .Get(x => x.EmailAddress == email && !x.DeletedDate.HasValue && x.IsValid == true)
      .Include(x => x.Role)
      .FirstOrDefault();
    if (admin is null) return DomainResult.Admin.NotFoundResult();
    if (admin.IsValid == false) return DomainResult.Admin.NotValidResult();
    if (admin.DeletedDate.HasValue) return DomainResult.Admin.DeletedResult();
    //if (admin.Role.Permissions.Count == 0) return DomainResult.Admin.NotHavePermissionResult();
    return admin;
  }

  public ResultData<Admin> GetAdmin(int id) {
    var admin = _unitOfWork.AdminRepository.Get(x => x.Id == id && !x.DeletedDate.HasValue && x.IsValid == true)
      .Include(x => x.Role)
      .FirstOrDefault();
    if (admin is null) return DomainResult.Admin.NotFoundResult();
    if (admin.IsValid == false) return DomainResult.Admin.NotValidResult();
    if (admin.DeletedDate.HasValue) return DomainResult.Admin.DeletedResult();
    //if (admin.Role.Permissions.Count == 0) return DomainResult.Admin.NotHavePermissionResult();
    return admin;
  }
  //public bool HasPermission(int adminId, int permissionId)
  //{
  //    var isValid = IsValidPermission(permissionId);
  //    if(!isValid) return false;

  //    var roleId = _unitOfWork.AdminRepository
  //        .Get(x => x.Id == adminId && !x.DeletedDate.HasValue && x.IsValid == true)
  //        .Include(x => x.Role)
  //        .Select(x => x.RoleId)
  //        .FirstOrDefault(0);
  //    if (roleId == 0) return false;
  //    return _unitOfWork.RolePermissionRepository.Any(x => x.RoleId == roleId && x.PermissionId == permissionId);
  //}


  public bool IsValidAdminAccount(int id) {
    return _unitOfWork.AdminRepository.Any(x => x.Id == id && !x.DeletedDate.HasValue && x.IsValid == true);
  }

  public bool Exists(int id) {
    return _unitOfWork.AdminRepository.Any(x => x.Id == id);
  }

  public bool Exists(string email) {
    return _unitOfWork.AdminRepository.Any(x => x.EmailAddress == email);
  }

  public List<Admin> GetAdmins() {
    return _unitOfWork.AdminRepository.Get().ToList();
  }

  public Result AddAdmin(AddAdminRequest admin) {
    _unitOfWork.AdminRepository.Insert(admin.ToAdminEntity());
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();

    return DomainResult.Admin.AddSuccessResult();
  }

  public int GetAdminRoleId(int adminId) {
    return _unitOfWork.AdminRepository
      .Get(x => x.Id == adminId && x.IsValid == true && !x.DeletedDate.HasValue)
      .Select(x => x.RoleId)
      .FirstOrDefault(0);
  }


  public Result ChangePassword(ChangePasswordRequest model) {
    var admin = _unitOfWork.AdminRepository.GetById(model.AuthenticatedAdminId);
    if (admin is null) return DomainResult.Admin.NotFoundResult();
    if (admin.Password != model.EncryptedOldPassword) return DomainResult.Base.PasswordWrongResult();
    admin.Password = model.EncryptedNewPassword;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Admin.ChangePasswordSuccessResult();
  }

  public ResultData<AdminDto> Login(LoginRequest model) {
    var adminResult = _unitOfWork.AdminRepository
      .Get(x => x.EmailAddress == model.EmailAddress)
      //.ThenInclude(x => x.PermissionRoles)
      //.ThenInclude(x => x.Permission)
      .Select(x => new {
        x.Password,
        AdminDto = new AdminDto {
          EmailAddress = x.EmailAddress,
          Permissions = x.Role.PermissionRoles.Select(x => x.Permission.Name).ToArray(),
          RoleId = x.RoleId,
          RoleName = x.Role.Name,
          TwoFactorType = x.TwoFactorType,
          Id = x.Id
        }
      })
      .FirstOrDefault();

    if (adminResult is null) return DomainResult.Admin.NotFoundResult();
    if (adminResult.Password != model.EncryptedPassword) return DomainResult.Admin.NotFoundResult();

    if (adminResult.AdminDto.Permissions.Length == 0) return DomainResult.Admin.NotHavePermissionResult();
    if (adminResult.AdminDto.TwoFactorType != 0) {
      //TODO: two factor
    }

    return adminResult.AdminDto;
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

  public Result EnableOrDisableAdmin(int authorAdminId, int adminId) {
    //TODO: maybe check admin permissions here as well
    var admin = _unitOfWork.AdminRepository.GetById(adminId);
    if (admin is null) return DomainResult.Admin.NotFoundResult();
    admin.IsValid = !admin.IsValid;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();
    return DomainResult.Admin.UpdateSuccessResult();
  }

  public Result DeleteAdmin(int authorAdminId, int adminId) {
    var admin = _unitOfWork.AdminRepository.GetById(adminId);
    if (admin is null) return DomainResult.Admin.NotFoundResult();

    if (admin.DeletedDate.HasValue) return DomainResult.Admin.DeletedResult();
    admin.DeletedDate = DateTime.Now;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalErrorResult();

    return DomainResult.Admin.DeleteSuccessResult();
  }
}