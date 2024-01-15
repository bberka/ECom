using ECom.Foundation.Static;

namespace ECom.Database;

internal static class SeedData
{
  internal static readonly List<User> Users = new() {
    new User {
      Id = new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
      EmailAddress = "user@mail.com",
      PhoneNumber = "5526667788",
      FirstName = "John",
      LastName = "Doe",
      Culture = StaticValues.DEFAULT_LANGUAGE,
      RegisterDate = StaticValues.DEFAULT_DATE_TIME,
      Password = "6759BF4BD24209B74B0B6374921F45D3317CFBA9B1F72374563F8E25B49108DC", //123456789
      TwoFactorKey = null,
      IsEmailVerified = true,
      OAuthType = OAuthType.None
    }
  };

  internal static readonly List<Admin> Admins = new() {
    new Admin {
      EmailAddress = "owner@mail.com",
      Password = "6759BF4BD24209B74B0B6374921F45D3317CFBA9B1F72374563F8E25B49108DC", //123456789
      RoleId = StaticValues.OWNER_ROLE_ID,
      TwoFactorType = TwoFactorType.None,
      Id = new Guid("5993a4f6-ff07-4635-97a4-a7c94c8b22ff"),
      DeleteDate = null,
      RegisterDate = StaticValues.DEFAULT_DATE_TIME,
      TwoFactorKey = null,
      PhoneNumber = "5526667788",
      FirstName = "John",
      LastName = "Doe",
      Culture = StaticValues.DEFAULT_LANGUAGE
    }
  };

  internal static readonly CompanyInformation CompanyInformation = new() {
    Key = true,
    CompanyAddress = "Worldwide",
    CompanyName = "ZDK Network",
    ContactEmail = "contact@zdk.network",
    Description = "Company Description"
  };


  internal static readonly Option Option = new();

  internal static readonly Role OwnerRole = new() {
    Id = StaticValues.OWNER_ROLE_ID
  };

  internal static readonly List<PermissionRole> OwnerPermissionRoles = StaticValues.ADMIN_PERMISSION_TYPES
                                                                                   .Select(x => new PermissionRole {
                                                                                     PermissionType = x,
                                                                                     RoleId = StaticValues.OWNER_ROLE_ID
                                                                                   })
                                                                                   .ToList();

  public static List<ProductAttributeType> ProductAttributes => new() {
    new ProductAttributeType {
      Id = new Guid("a624e2b7-46ee-4c95-9081-707ba9c81441"),
      Name = "Color"
    },
    new ProductAttributeType {
      Id = new Guid("f3a3b240-0c44-40e0-88fb-0471ef44ae50"),
      Name = "Size"
    },
    new ProductAttributeType {
      Id = new Guid("43eef28a-641a-4f34-8a34-25aa3524695e"),
      Name = "Weight"
    },
    new ProductAttributeType {
      Id = new Guid("a9b00b37-ac6f-4b95-9e21-76db887b87b2"),
      Name = "Storage"
    },
    new ProductAttributeType {
      Id = new Guid("2f0f9bda-80b8-4391-8caf-ca4bdfad1b0e"),
      Name = "Ram"
    },
    new ProductAttributeType {
      Id = new Guid("bcb24b43-c497-4458-af78-6eb7fed4d197"),
      Name = "Processor"
    },
    new ProductAttributeType {
      Id = new Guid("e3794732-f6e3-4478-9dcb-accedad23476"),
      Name = "Screen Size"
    },
    new ProductAttributeType {
      Id = new Guid("50b069df-31a0-4ade-a553-17385b72c5db"),
      Name = "Screen Resolution"
    },
    new ProductAttributeType {
      Id = new Guid("3bf9af7b-05c1-47df-bb90-476322511eeb"),
      Name = "Battery"
    },
    new ProductAttributeType {
      Id = new Guid("b8b5b910-dfbe-4817-9f8d-26473ba51f9f"),
      Name = "Operating System"
    },
    new ProductAttributeType {
      Id = new Guid("243a05ef-d2ff-4b56-8c45-a7372c0584c3"),
      Name = "Brand"
    },
    new ProductAttributeType {
      Id = new Guid("834e45c4-c689-4273-9b47-0276f8553cdb"),
      Name = "Model"
    },
    new ProductAttributeType {
      Id = new Guid("d397fcd8-9c74-4783-8dc7-5d8f0e10208c"),
      Name = "Year"
    },
    new ProductAttributeType {
      Id = new Guid("13d18764-bdec-4c5b-900a-a478f295d93f"),
      Name = "Material"
    }
  };
}