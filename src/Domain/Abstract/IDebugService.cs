using ECom.Domain.DTOs.AdminDTOs;
using ECom.Domain.DTOs.UserDTOs;

namespace ECom.Domain.Abstract
{

public interface IDebugService
{
    void CheckAndThrowDebug();
    User GetUser();
    Admin GetAdmin();

    AdminDto GetAdminDto();

    UserDto GetUserDto();
}
}