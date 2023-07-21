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
      RoleId = "Owner",
      TwoFactorType = TwoFactorType.None,
      Id = new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
      DeleteDate = null,
      RegisterDate = ConstantMgr.DefaultDateTime,
      TwoFactorKey = null,
    
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