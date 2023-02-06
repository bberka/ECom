using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECom.Domain.Entities;


namespace ECom.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IEfEntityRepository<Role> _roleRepo;
        private readonly IEfEntityRepository<RolePermission> _rolePermissionRepo;
        private readonly IEfEntityRepository<Permission> _permissionRepo;
        private readonly IAdminService _adminService;

        public RoleService(
            IEfEntityRepository<Role> roleRepo,
            IEfEntityRepository<RolePermission> rolePermissionRepo,
            IEfEntityRepository<Permission> permissionRepo,
            IAdminService adminService)
        {
            this._roleRepo = roleRepo;
            this._rolePermissionRepo = rolePermissionRepo;
            this._permissionRepo = permissionRepo;
            this._adminService = adminService;
        }

        public List<Permission> GetAdminPermissions(int adminId)
        {
            var admin = _adminService.GetValidAdminOrThrow(adminId);
            var roleBinds = _rolePermissionRepo
                .GetList(x => x.RoleId == admin.RoleId)
                .Select(x => x.PermissionId);
            var permissions = _permissionRepo
                .GetList(x => x.IsValid == true && roleBinds.Contains(x.Id));
            return permissions;
        }

        public List<Permission> GetValidPermissionsList()
        {
            return _permissionRepo.GetList(x => x.IsValid == true);
        }

        public List<Permission> GetRolePermissions(int roleId)
        {
            var perms = _rolePermissionRepo
                .GetList(x => x.RoleId == roleId)
                .Select(x => x.PermissionId);
            return _permissionRepo.GetList(x => x.IsValid == true && perms.Contains(x.Id));
        }

        public bool HasPermission(int adminId, int permissionId)
        {
            var admin = _adminService.GetValidAdminOrThrow(adminId);
            return _rolePermissionRepo.Any(x => x.PermissionId == permissionId && x.RoleId == admin.RoleId);
        }

        public bool HasPermission(int adminId, string permissionName)
        {
            var admin = _adminService.GetValidAdminOrThrow(adminId);
            var perm = _permissionRepo.GetFirstOrDefault(x => x.Name == permissionName);
            if (perm is null) return false;
            return _rolePermissionRepo.Any(x => x.RoleId == admin.RoleId && x.PermissionId == perm.Id);
        }

        public List<RolePermission> GetRoleBinds()
        {
            return _rolePermissionRepo.GetList();
        }

        public List<RolePermission> GetAdminRoleBinds(int adminId)
        {
            var roleId = _adminService.GetAdminRoleId(adminId);  
            return _rolePermissionRepo.GetList(x => x.RoleId == roleId);

        }

    }
}
