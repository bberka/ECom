using ECom.Foundation.Static;

namespace ECom.Business.Services;

public class DebugService : IDebugService
{
  private readonly IUnitOfWork _unitOfWork;

  public DebugService(
    IUnitOfWork unitOfWork) {
    _unitOfWork = unitOfWork;
  }

  public void CheckAndThrowDebug() {
    if (!StaticValues.IS_DEVELOPMENT) throw new Exception("Only available when debugging");
  }

  public User GetUser() {
    CheckAndThrowDebug();
    return _unitOfWork.Users.FirstOrDefault();
  }

  public Admin GetAdmin() {
    CheckAndThrowDebug();
    return _unitOfWork.Admins.Where(x => x.RoleId == "Owner")
                      .Include(x => x.Role)
                      .ThenInclude(x => x.PermissionRoles)
                      .Single();
  }

  public AdminDto GetAdminDto() {
    var admin = GetAdmin();
    var dto = admin.ToDto();
    return dto;
  }

  public UserDto GetUserDto() {
    var user = GetUser();
    var dto = user.ToDto();
    return dto;
  }
}