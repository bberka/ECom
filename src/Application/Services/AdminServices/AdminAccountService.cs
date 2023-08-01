using ECom.Domain;
using ECom.Domain.Aspects;
using ECom.Shared.Abstract;
using ECom.Shared.Abstract.Services;
using ECom.Shared.Abstract.Services.Admin;
using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.AspNetCore.Components.Authorization;

namespace ECom.Application.Services.AdminServices;


[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminAccountService : IAdminAccountService
{
  protected readonly IAdminOptionService OptionService;
  protected readonly IAdminRoleService RoleService;
  protected readonly IUnitOfWork UnitOfWork;
  protected readonly IValidationService ValidationService;

  public AdminAccountService(
    IUnitOfWork unitOfWork,
    IAdminOptionService optionService,
    IValidationService validationService,
    IAdminRoleService roleService) {
    UnitOfWork = unitOfWork;
    OptionService = optionService;
    ValidationService = validationService;
    RoleService = roleService;

  }




  public CustomResult<AdminDto> Login(LoginRequest model) {
    var admin = UnitOfWork.Admins
      .Where(x => x.EmailAddress == model.EmailAddress)
      .Select(x => Admin.ToDto(x))
      .FirstOrDefault();
    if (admin is null) return DomainResult.NoAccountFound(nameof(Admin));
    if (admin.DeletedDate.HasValue) return DomainResult.Invalid(nameof(Admin));
    var encryptedPassword = model.IsHashed ? model.Password : model.Password.ToHashedText();
    if (!admin.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
      return DomainResult.NoAccountFound(nameof(Admin));
    if (admin.Permissions.Length == 0) return DomainResult.None("permission");
    if (admin.TwoFactorType != 0) {
      //TODO: two factor authentication
    }

    return admin;
  }

  public CustomResult<string> ResetPassword(Guid userId, ResetPasswordByTokenRequest token) {
    throw new NotImplementedException();
  }


  public CustomResult ChangePassword(Guid adminId, ChangePasswordRequestDto model) {
    var admin = UnitOfWork.Admins.Find(adminId);
    if (admin is null) return DomainResult.NotFound(nameof(Admin));
    var password = model.NewPassword.ToHashedText();
    if (admin.Password != password) return DomainResult.WrongPassword();
    admin.Password = password;
    admin.UpdateDate = DateTime.UtcNow;

    UnitOfWork.Admins.Update(admin);
    var res = UnitOfWork.Save();
    if (!res) return DomainResult.DbInternalError(nameof(ChangePassword));
    return DomainResult.OkUpdated("Password");
  }










}