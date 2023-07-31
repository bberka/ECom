using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

//internal class PermissionRoleConfiguration : IEntityTypeConfiguration<PermissionRole>
//{
//  public void Configure(EntityTypeBuilder<PermissionRole> builder) {
//    //builder.HasKey(x => new { x.RoleId, x.PermissionId });

//    //builder.HasOne(x => x.Role)
//    //  .WithMany(x => x.Permissions)
//    //  .HasForeignKey(x => x.RoleId);

//    //builder.HasOne(x => x.Permission)
//    //  .WithMany(x => x.PermissionRoles)
//    //  .HasForeignKey(x => x.PermissionId);

//    builder.Navigation(x => x.Permission).AutoInclude();

//    var names = Enum.GetNames(typeof(AdminPermission));
//    var permissions = new List<PermissionRole>();
//    foreach (var name in names)
//      permissions.Add(new PermissionRole {
//        PermissionId = name,
//        RoleId = "Owner"
//      });

//    builder.HasData(permissions);
//  }
//}