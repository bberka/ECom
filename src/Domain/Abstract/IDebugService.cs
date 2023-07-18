using ECom.Domain.DTOs.AdminDto;
using ECom.Domain.DTOs.UserDto;

namespace ECom.Domain.Abstract;

public interface IDebugService
{
  void CheckAndThrowDebug();
  User GetUser();
  Admin GetAdmin();

  AdminDto GetAdminDto();

  UserDto GetUserDto();
}