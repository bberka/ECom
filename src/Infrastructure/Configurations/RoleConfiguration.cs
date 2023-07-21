using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  public void Configure(EntityTypeBuilder<Role> builder) {
    builder.Navigation(x => x.PermissionRoles).AutoInclude();
    var names = Enum.GetValues(typeof(AdminPermission));
    var roles = new List<Role>();
    foreach (var name in names)
      roles.Add(new Role {
        Id = name.ToString()
      });

    builder.HasData(roles);
  }
}