using ECom.Foundation.DTOs;

namespace ECom.Foundation.Abstract.Services;

public interface IDebugService
{
  void CheckAndThrowDebug();
  Entities.User GetUser();
  Entities.Admin GetAdmin();

  AdminDto GetAdminDto();

  UserDto GetUserDto();
}