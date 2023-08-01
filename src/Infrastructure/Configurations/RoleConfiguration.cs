using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder) {

    builder.Navigation(x => x.PermissionRoles).AutoInclude();
    var temp = SeedData.OwnerRole;
    builder.HasData(temp);
  }
}