using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECom.Application.Services
{
	public interface IRoleService 
	{
	}
	public class RoleService : IRoleService
	{
		private readonly IEfEntityRepository<Role> _roleRepo;
		private readonly IEfEntityRepository<RoleBind> _roleBindRepo;
		private readonly IEfEntityRepository<Permission> _permissionRepo;

		public RoleService(
			IEfEntityRepository<Role> roleRepo, 
			IEfEntityRepository<RoleBind> roleBindRepo,
			IEfEntityRepository<Permission> permissionRepo)
		{
			this._roleRepo = roleRepo;
			this._roleBindRepo = roleBindRepo;
			this._permissionRepo = permissionRepo;
		}
	}
}
