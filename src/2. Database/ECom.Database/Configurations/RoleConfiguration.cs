using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Database.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder) {
    builder.Navigation(x => x.PermissionRoles).AutoInclude();
    var temp = SeedData.OwnerRole;
    builder.HasData(temp);
  }
}