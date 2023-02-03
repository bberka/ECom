using ECom.Infrastructure.Interfaces;

namespace ECom.Application.Manager
{
	public class AdminAuthenticator : IAuthenticator<Admin>
	{
		private readonly IAdminService _adminService;

		public AdminAuthenticator(IAdminService adminService)
		{
			this._adminService = adminService;
		}

		public ResultData<Admin> Authenticate(LoginModel model)
		{
			return _adminService.Login(model);
		}
	}
}
