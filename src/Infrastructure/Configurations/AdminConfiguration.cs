using ECom.Domain.Entities;
using ECom.Shared.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECom.Infrastructure.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
  private static readonly List<Admin> _admins = new() {
    new Admin {
      EmailAddress = "owner@mail.com",
      Password = "25f9e794323b453885f5181f1b624d0b", //123456789
      RoleId = 1,
      TwoFactorType = 0,
      Id = 1,
      DeletedDate = null,
      RegisterDate = ConstantMgr.DefaultDateTime,
      TwoFactorKey = null
    },
    new Admin {
      EmailAddress = "admin@mail.com",
      Password = "25f9e794323b453885f5181f1b624d0b", //123456789
      RoleId = 2,
      TwoFactorType = 0,
      Id = 2,
      DeletedDate = null,
      RegisterDate = ConstantMgr.DefaultDateTime,
      TwoFactorKey = null
    },
    new Admin {
      EmailAddress = "mod@admin.com",
      Password = "25f9e794323b453885f5181f1b624d0b", //123456789
      RoleId = 3,
      TwoFactorType = 0,
      Id = 3,
      DeletedDate = null,
      RegisterDate = ConstantMgr.DefaultDateTime,
      TwoFactorKey = null
    }
  };

  public void Configure(EntityTypeBuilder<Admin> builder) {
    builder.Navigation(x => x.Role).AutoInclude();
    builder.HasData(_admins);
  }
}