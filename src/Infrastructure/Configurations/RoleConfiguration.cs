using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder) {

    builder.Navigation(x => x.Permissions).AutoInclude();
    var temp = SeedData.AdminRole;
    temp.Permissions = new List<Permission>();
    builder.HasData(temp);
  }
}