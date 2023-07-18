using ECom.Domain;
using ECom.Domain.DTOs.AdminDto;
using ECom.Domain.Entities;
using ECom.Domain.Extensions;

namespace ECom.Application.Services;

public class AdminService : IAdminService
{
  private readonly IOptionService _optionService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidationService _validationService;
  private readonly IRoleService _roleService;

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


  public CustomResult<Admin> GetAdmin(string email) {
    var admin = _unitOfWork.AdminRepository
      .Get(x => x.EmailAddress == email && !x.DeletedDate.HasValue)
      .Include(x => x.Role)
      .FirstOrDefault();
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    //if (admin.Role.Permissions.Count == 0) return DomainResult.Admin.NotHavePermission();
    return admin;
  }

  public CustomResult<AdminDto> GetAdminDto(int id) {
    var adminQuery = _unitOfWork.AdminRepository
      .Get(x => x.Id == id)
      .Select(x => AdminDto.FromEntity(x))
      .FirstOrDefault();
    if (adminQuery is null) return DomainResult.NotFound(nameof(Admin));
    if (adminQuery.DeletedDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    return adminQuery;
  }

  public CustomResult<AdminDto> GetAdminDto(string email) {
    var adminQuery = _unitOfWork.AdminRepository
      .Get(x => x.EmailAddress == email)
      .Select(x => AdminDto.FromEntity(x))
      .FirstOrDefault();
    if (adminQuery is null) return DomainResult.NotFound(nameof(Admin));
    if (adminQuery.DeletedDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    return adminQuery;
  }

  public CustomResult<Admin> GetAdmin(int id) {
    var admin = _unitOfWork.AdminRepository.Get(x => x.Id == id && !x.DeletedDate.HasValue)
      .Include(x => x.Role)
      .FirstOrDefault();
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    return admin;
  }

  public CustomResult<AdminDto> AdminLogin(LoginRequest model) {
    var adminResult = GetAdminDto(model.EmailAddress);
    if (!adminResult.Status) return adminResult;
    var admin = adminResult.Data!;
    var encryptedPassword = model.IsHashed ? model.Password : model.Password.ToEncryptedText();
    if (!admin.Password.Equals(encryptedPassword,StringComparison.OrdinalIgnoreCase)) return DomainResult.NotFound(nameof(Admin));
    if (admin.Permissions.Length == 0) return DomainResult.None(nameof(Permission));
    if (admin.TwoFactorType != 0) {
      //TODO: two factor authentication
    }
    return admin;
  }

  public bool IsValidAdminAccount(int id) {
    return _unitOfWork.AdminRepository.Any(x => x.Id == id && !x.DeletedDate.HasValue);
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
    var roleExist = _roleService.RoleExists(admin.RoleId);
    if (!roleExist) return DomainResult.NotFound(nameof(Role));
    var adminExist = AdminExists(admin.EmailAddress);
    if (adminExist) return DomainResult.AlreadyExists(nameof(Admin.EmailAddress));
    _unitOfWork.AdminRepository.Insert(admin.ToAdminEntity());
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(AddAdmin));
    return DomainResult.OkAdded(nameof(Admin));
  }

  public int GetAdminRoleId(int adminId) {
    return _unitOfWork.AdminRepository
      .Get(x => x.Id == adminId && !x.DeletedDate.HasValue)
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

  public List<AdminDto> ListOtherAdmins(int adminId) {
    return _unitOfWork.AdminRepository
      .Get(x => x.Id != adminId)
      .Include(x => x.Role)
      .Select(x => AdminDto.FromEntity(x))
      .ToList();
  }




  public CustomResult DeleteAdmin(int authorAdminId, int adminId) {
    var admin = _unitOfWork.AdminRepository.GetById(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.AlreadyDeleted(nameof(Admin));
    admin.DeletedDate = DateTime.Now;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(DeleteAdmin));
    return DomainResult.OkDeleted(nameof(Admin));
  }

  public CustomResult UpdateAdmin(int requestAuthenticatedAdminId, UpdateAdminAccountRequest request) {
    var admin = _unitOfWork.AdminRepository.GetById(request.Id);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    var isAllSame = admin.EmailAddress == request.EmailAddress && admin.RoleId == request.RoleId;
    if (request.UpdatePassword && !string.IsNullOrEmpty(request.Password)) {
      var tempPass = admin.Password;
      admin.Password = request.Password.ToEncryptedText();
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
    
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(UpdateAdmin));
    return DomainResult.OkUpdated(nameof(Admin));
    
  }

  public CustomResult RecoverAdmin(int authorAdminId, int id) {
    var admin = _unitOfWork.AdminRepository.GetById(id);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    if (!admin.DeletedDate.HasValue) return DomainResult.NotDeleted(nameof(Admin));
    admin.DeletedDate = null;
    _unitOfWork.AdminRepository.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(RecoverAdmin));
    return DomainResult.OkUpdated(nameof(Admin));
  }
}