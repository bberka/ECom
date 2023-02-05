
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Entities;
using ECom.Domain.Interfaces;


namespace ECom.Application.Manager
{
    public class UserAuthenticator : IAuthenticator<User>
	{
		private readonly IUserService _userService;

		public UserAuthenticator(IUserService userService)
		{
			this._userService = userService;
		}

		public ResultData<User> Authenticate(LoginRequestModel model)
		{
			return _userService.Login(model);
		}
	}
}
