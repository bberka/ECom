using ECom.Domain.Entities;

namespace ECom.Domain.Abstract.Services;

public interface IDebugService
{
    void CheckAndThrowDebug();
    Entities.User GetUser();
    Entities.Admin GetAdmin();

    AdminDto GetAdminDto();

    UserDto GetUserDto();
}