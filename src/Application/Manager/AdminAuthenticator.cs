using ECom.Domain.ApiModels.Request;
using ECom.Domain.Interfaces;

namespace ECom.Application.Manager
{
    public class AdminAuthenticator : IAuthenticator<Admin>
	{
		private readonly IAdminService _adminService;

		public AdminAuthenticator(IAdminService adminService)
		{
			this._adminService = adminService;
		}

		public ResultData<Admin> Authenticate(LoginRequestModel model)
		{
			return _adminService.Login(model);
		}
	}
}
