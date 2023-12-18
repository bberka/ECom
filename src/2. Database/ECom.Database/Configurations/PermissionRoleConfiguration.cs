using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Database.Configurations;

internal class PermissionRoleConfiguration : IEntityTypeConfiguration<PermissionRole>
{
  public void Configure(EntityTypeBuilder<PermissionRole> builder) {
    builder.Property(x => x.PermissionType)
           .HasConversion(new EnumToNumberConverter<AdminPermissionType, int>());

    builder.HasData(SeedData.OwnerPermissionRoles);
  }
}