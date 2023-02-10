using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations
{
    internal class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            var permList = CommonLib.GetAdminOperationTypes();
            var rolePermList = new List<RolePermission>();
            for (int i = 1; i < permList.Length; i++)
            {
                rolePermList.Add(new RolePermission
                {
                    PermissionId = i,
                    RoleId = 1
                });
            }

            builder.HasData(rolePermList);
        }
    }
}
