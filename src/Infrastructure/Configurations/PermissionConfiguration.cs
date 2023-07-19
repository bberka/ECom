using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
  public void Configure(EntityTypeBuilder<Permission> builder) {
    builder.Navigation(x => x.PermissionRoles).AutoInclude();
    var enumValues = Enum.GetValues(typeof(AdminOperationType));
    var permissions = new List<Permission>();

    foreach (var value in enumValues)
      permissions.Add(new Permission {
        Name = value.ToString(),
        Id = (int)value,
        IsValid = true,
        Memo = null
      });

    builder.HasData(permissions);
  }
}