using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
  private static readonly List<Admin> _admins = new() {
    new Admin {
      EmailAddress = "owner@mail.com",
      Password = "25f9e794323b453885f5181f1b624d0b", //123456789
      RoleId = RoleType.Owner.ToString(),
      TwoFactorType = TwoFactorType.None,
      Id = Guid.NewGuid(),
      DeleteDate = null,
      RegisterDate = ConstantMgr.DefaultDateTime,
      TwoFactorKey = null
    },
  };

  public void Configure(EntityTypeBuilder<Admin> builder) {
    builder.Navigation(x => x.Role).AutoInclude();
    builder.HasData(_admins);
    builder.Property(x => x.TwoFactorType)
      .HasConversion(new EnumToNumberConverter<TwoFactorType, byte>())
      .HasDefaultValue(TwoFactorType.None);
  }
}