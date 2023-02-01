using System.Linq.Expressions;

namespace ECom.Infrastructure.Abstract
{
    public interface IEfAdmin
    {
        public bool HasPermission (int adminId,int permissionId);
    }
}
