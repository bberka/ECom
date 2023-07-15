using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
  public void Configure(EntityTypeBuilder<Permission> builder) {
    builder.Navigation(x => x.PermissionRoles).AutoInclude();

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