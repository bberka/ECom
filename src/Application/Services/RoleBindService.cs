using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	public interface IRoleBindService : IEfEntityRepository<RoleBind>
	{

	}
    public class RoleBindService : EfEntityRepositoryBase<RoleBind, EComDbContext>, IRoleBindService
	{

	}
}
