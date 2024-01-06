using ECom.Foundation.Static;

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


  public Result ChangePassword(Guid adminId,
                               Request_Password_Change model) {
    //TODO: Validation with DB Options ?
    var admin = _unitOfWork.Admins.Single(x => x.Id == adminId && !x.IsDeleted);
    var isMatch = model.NewPassword.Equals(model.RepeatNewPassword, StringComparison.OrdinalIgnoreCase);
    if (!isMatch)
      return DomResults.x_must_be_same_with_y("new_password", "repeat_new_password");
    var isSameWithOldPassword = model.OldPassword.Equals(model.NewPassword, StringComparison.OrdinalIgnoreCase);
    if (isSameWithOldPassword)
      return DomResults.x_can_not_be_same_with_y("new_password", "old_password");
    var password = model.OldPassword.ToHashedText();
    var encryptedPassword = model.OldPassword.ToHashedText();
    if (!admin.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
      return DomResults.wrong_password();
    admin.Password = model.NewPassword.ToHashedText();
    admin.UpdateDate = DateTime.UtcNow;
    _unitOfWork.Admins.Update(admin);
    var res = _unitOfWork.Save();
    if (!res)
      return DomResults.db_internal_error(nameof(ChangePassword));

    return DomResults.x_is_updated_successfully("password");
  }

  public Result UpdateMyAccount(Request_Admin_UpdateAccount admin) {
    throw new NotImplementedException();
  }

  public AdminDto GetAccountInformation(Guid authId) {
    var adminDto = _unitOfWork.Admins
                              .AsNoTracking()
                              .Include(x => x.Role)
                              .ThenInclude(x => x.PermissionRoles)
                              .Where(x => x.Id == authId)
                              .Select(x => x.ToDto())
                              .SingleOrDefault();
    return adminDto;
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
  //   if (admin is null) return DomResults.NoAccountFound("admin");
  //   if (admin.Dto.DeleteDate.HasValue) return DomResults.x_is_invalid("admin");
  //   var encryptedPassword = model.Password.ToHashedText();
  //   if (!admin.Password.Equals(encryptedPassword, StringComparison.OrdinalIgnoreCase))
  //     return DomResults.NoAccountFound("admin");
  //   if (admin.Dto.Permissions.Length == 0) return DomResults.None("permission");
  //   if (admin.Dto.TwoFactorType != 0) {
  //     //TODO: two factor authentication
  //   }
  //
  //   return admin.Dto;
  // }

  public Result<string> ResetPassword(Guid userId,
                                      Request_Password_ResetByToken token) {
    throw new NotImplementedException();
  }
}