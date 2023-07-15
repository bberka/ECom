using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class PermissionRoleConfiguration : IEntityTypeConfiguration<PermissionRole>
{
  public void Configure(EntityTypeBuilder<PermissionRole> builder) {
    builder.HasKey(x => new { x.RoleId, x.PermissionId });

    builder.HasOne(x => x.Role)
      .WithMany(x => x.PermissionRoles)
      .HasForeignKey(x => x.RoleId);

    builder.HasOne(x => x.Permission)
      .WithMany(x => x.PermissionRoles)
      .HasForeignKey(x => x.PermissionId);

    builder.Navigation(x => x.Permission).AutoInclude();
    builder.Navigation(x => x.Role).AutoInclude(); //This may not be necessary


    //var permEnumList = CommonLib.GetAdminOperationTypes();
    //var permList  = new ListProducts<Permission>();
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