using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder) {
    builder.Navigation(x => x.PermissionRoles).AutoInclude();
    var roles = new List<Role>();
    roles.Add(new Role() {
      Id = "Owner"
    });
    builder.HasData(roles);
  }
}