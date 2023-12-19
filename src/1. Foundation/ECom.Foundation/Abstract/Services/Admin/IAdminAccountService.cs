using ECom.Foundation.Abstract.Services.Base;
using ECom.Foundation.DTOs;
using ECom.Foundation.DTOs.Request;

namespace ECom.Foundation.Abstract.Services.Admin;

public interface IAdminAccountService : IAccountService<AdminDto>
{
  Result UpdateMyAccount(Request_Admin_UpdateAccount admin);
  AdminDto GetAccountInformation(Guid authId);
}