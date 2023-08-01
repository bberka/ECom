using ECom.Shared;
using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

internal class PermissionRoleConfiguration : IEntityTypeConfiguration<PermissionRole>
{
  public void Configure(EntityTypeBuilder<PermissionRole> builder) {
    builder.Property(x => x.Permission)
      .HasConversion(new EnumToNumberConverter<AdminPermission,int>());

    builder.HasData(SeedData.OwnerPermissionRoles);
  }
}