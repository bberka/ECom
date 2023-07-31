using ECom.Shared.Constants;
using ECom.Shared.Entities;

namespace ECom.Infrastructure;

internal static class SeedData
{
  internal static readonly List<Admin> Admins = new() {
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
  internal static readonly CompanyInformation CompanyInformation = new() {
    CompanyAddress = "Address",
    CompanyName = "CompanyName",
    ContactEmail = "contact@support.com",
    Description = "Company Description",
    DomainUrl = "www.company.com",
    FacebookLink = "facebook.com/company",
    InstagramLink = "instagram.com/company",
    Key = true,
    PhoneNumber = "5526667788",
    WebApiUrl = "api.company.com",
    WhatsApp = "5526667788",
    YoutubeLink = "yt.com/company"
  };
  internal static readonly List<Permission> Permissions = Enum.GetNames(typeof(AdminPermission)).Select(x => new Permission() {
    Id = x
  }).ToList();

  internal static readonly Option Option = new();

  internal static readonly Role AdminRole = new Role() {
    Id = "Owner",
    Permissions = Permissions
  };
}