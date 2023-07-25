

namespace ECom.Shared.Abstract.Services;

public interface IDebugService
{
    void CheckAndThrowDebug();
    Shared.Entities.User GetUser();
    Shared.Entities.Admin GetAdmin();

    AdminDto GetAdminDto();

    UserDto GetUserDto();
}