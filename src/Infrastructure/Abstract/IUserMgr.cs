using System.Linq.Expressions;

namespace ECom.Infrastructure.Abstract
{
    public interface IUserMgr
	{
		public ResultData<User> Login(LoginModel model);
		public bool UpdateSuccessLogin(User user);
		public bool IncreaseFailedPasswordCount(User user);
	}
}
