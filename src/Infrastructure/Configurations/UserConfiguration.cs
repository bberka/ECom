using ECom.Shared.Constants;
using ECom.Shared.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ECom.Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
  //private static readonly List<User> _users = new() {
  //  new User {
  //    EmailAddress = "debug@mail.com",
  //    Password = "25f9e794323b453885f5181f1b624d0b", //123456789
  //    FirstName = "User",
  //    PhoneNumber = "5525553344",
  //    TwoFactorType = 0,
  //    LastName = "Last",
  //    DeleteDate = null,
  //    RegisterDate = ConstantMgr.DefaultDateTime,
  //    TwoFactorKey = null,
  //    CitizenShipNumber = null,
  //    Culture = "tr",
  //    Id = 1,
  //    IsEmailVerified = false,
  //    OAuthKey = null,
  //    OAuthType = null,
  //    TaxNumber = null
  //  },
  //  new User {
  //    EmailAddress = "debug2@mail.com",
  //    Password = "25f9e794323b453885f5181f1b624d0b", //123456789
  //    FirstName = "User",
  //    PhoneNumber = "5525553344",
  //    TwoFactorType = 0,
  //    LastName = "Last",
  //    DeleteDate = null,
  //    RegisterDate = ConstantMgr.DefaultDateTime,
  //    TwoFactorKey = null,
  //    CitizenShipNumber = null,
  //    Culture = "tr",
  //    Id = 2,
  //    IsEmailVerified = false,
  //    OAuthKey = null,
  //    OAuthType = null,
  //    TaxNumber = null
  //  }
  //};

  public void Configure(EntityTypeBuilder<User> builder) {
    //builder.HasData(_users);
    builder.Property(x => x.TwoFactorType)
      .HasConversion(new EnumToNumberConverter<TwoFactorType, byte>())
      .HasDefaultValue(TwoFactorType.None);
    builder.Property(x => x.OAuthType)
      .HasConversion(new EnumToNumberConverter<OAuthType, byte>())
      .HasDefaultValue(OAuthType.None);
  }
}