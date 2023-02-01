using System.Linq.Expressions;

namespace ECom.Infrastructure.Abstract
{
    public interface IAdminMgr
    {
        public bool HasPermission (int adminId,int permissionId);
		public ResultData<Admin> Login(LoginModel model);
		public bool UpdateSuccessLogin(Admin admin);
		public bool IncreaseFailedPasswordCount(Admin admin);
	}
}
