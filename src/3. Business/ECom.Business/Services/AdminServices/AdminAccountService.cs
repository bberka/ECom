namespace ECom.Business.Services.AdminServices;

[PerformanceLoggerAspect]
[ExceptionLoggerAspect]
public class AdminAccountService : IAdminAccountService
{
  private readonly IAdminOptionService _optionService;
  private readonly IAdminRoleService _roleService;
  private readonly IUnitOfWork _unitOfWork;
  private readonly IValidationService _validationService;

  public AdminAccountService(
    IUnitOfWork unitOfWork,
    IAdminOptionService optionService,
    IValidationService validationService,
    IAdminRoleService roleService) {
    _unitOfWork = unitOfWork;
    _optionService = optionService;
    _validationService = validationService;
    _roleService = roleService;
  }


  public Result ChangePassword(Guid adminId, Request_Password_Change model) {
    //TODO: Validation with DB Options ?
    var admin = _unitOfWork.Admins.Find(adminId);
    if (admin is null) return DefResult.NotFound(nameof(Admin));
    var isMatch = model.NewPassword.Equals(model.RepeatNewPassword, StringComparison.OrdinalIgnoreCase);
    if (!isMatch) return DefResult.MustBeSame("old_password", "new_password");
    var password = model.OldPassword.ToHashedText();
    var encryptedPassword = model.OldPassword.ToHashedText();
    if (!admin.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
      return DefResult.WrongPassword();
    admin.Password = model.NewPassword.ToHashedText();
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res) return DefResult.DbInternalError(nameof(ChangePassword));
    return DefResult.OkUpdated("Password");
  }


  // public Result<AdminDto> Login(Request_Login model) {
  //   var admin = _unitOfWork.Admins
  //                          .AsNoTracking()
  //                          .Include(x => x.Role)
  //                          .ThenInclude(x => x.PermissionRoles)
  //                          .Where(x => x.EmailAddress == model.EmailAddress)
  //                          .Select(x => new {
  //                            Dto = x.ToDto(),
  //                             x.Password,
  //                          })
  //                          .FirstOrDefault();
  //   if (admin is null) return DefResult.NoAccountFound(nameof(Admin));
  //   if (admin.Dto.DeleteDate.HasValue) return DefResult.Invalid(nameof(Admin));
  //   var encryptedPassword = model.Password.ToHashedText();
  //   if (!admin.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
  //     return DefResult.NoAccountFound(nameof(Admin));
  //   if (admin.Dto.Permissions.Length == 0) return DefResult.None("permission");
  //   if (admin.Dto.TwoFactorType != 0) {
  //     //TODO: two factor authentication
  //   }
  //
  //   return admin.Dto;
  // }

  public Result<string> ResetPassword(Guid userId, Request_Password_ResetByToken token) {
    throw new NotImplementedException();
  }
}