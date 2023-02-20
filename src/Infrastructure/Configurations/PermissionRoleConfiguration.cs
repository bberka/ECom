using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations
{
    internal class PermissionRoleConfiguration : IEntityTypeConfiguration<PermissionRole> 
    {

        public void Configure(EntityTypeBuilder<PermissionRole> builder)
        {
            builder.HasKey(x => new { x.RoleId, x.PermissionId });

            builder.HasOne(x => x.Role)
                .WithMany(x => x.PermissionRoles)
                .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.Permission)
                .WithMany(x => x.PermissionRoles)
                .HasForeignKey(x => x.PermissionId);

            //var permEnumList = CommonLib.GetAdminOperationTypes();
            //var permList  = new List<Permission>();
            //for (int i = 1; i < permEnumList.Length; i++)
            //{
            //    var str = permEnumList[i];
            //    permList.Add(new Permission()
            //    {
            //        Id = i,
            //        IsValid = true,
            //        Name = str
            //    });
            //}
            //builder.HasData(permList);
        }
    }
}
