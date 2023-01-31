using System.Linq.Expressions;
using ECom.Infrastructure.DataAccess;

namespace ECom.Infrastructure.Abstract
{
    public interface IEfAdmin
    {
        public bool IsInRole(int adminId,int roleId);
    }
}
