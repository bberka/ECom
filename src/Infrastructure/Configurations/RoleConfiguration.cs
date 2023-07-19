using ECom.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
  private static readonly List<Role> _roles = new() {
    new Role {
      IsValid = true,
      Name = "Owner",
      Id = 1
    },
    new Role {
      IsValid = true,
      Name = "Admin",
      Id = 2
    },
    new Role {
      IsValid = true,
      Name = "Moderator",
      Id = 3
    }
  };

  public void Configure(EntityTypeBuilder<Role> builder) {
    builder.Navigation(x => x.PermissionRoles).AutoInclude();
    builder.HasData(_roles);
  }
}