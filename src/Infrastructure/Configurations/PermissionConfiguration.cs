using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
  public void Configure(EntityTypeBuilder<Permission> builder) {
    builder.Navigation(x => x.PermissionRoles).AutoInclude();
    var enumValues = Enum.GetValues(typeof(AdminPermission));
    var permissions = new List<Permission>();

    foreach (var value in enumValues)
      permissions.Add(new Permission {
        Id = value.ToString(),
      });

    builder.HasData(permissions);
  }
}