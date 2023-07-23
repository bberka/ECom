using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IDebugService
{
  void CheckAndThrowDebug();
  User GetUser();
  Admin GetAdmin();

  AdminDto GetAdminDto();

  UserDto GetUserDto();
}