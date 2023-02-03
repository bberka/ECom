
using ECom.Domain.Entities;
using ECom.Infrastructure.Interfaces;


namespace ECom.Application.Manager
{
	public class UserAuthenticator : IAuthenticator<User>
	{
		private readonly IUserService _userService;

		public UserAuthenticator(IUserService userService)
		{
			this._userService = userService;
		}

		public ResultData<User> Authenticate(LoginModel model)
		{
			return _userService.Login(model);
		}
	}
}
