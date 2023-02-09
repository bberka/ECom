namespace ECom.Infrastructure
{
    internal static class BaseDbFiller
    {

        internal static void Run()
        {
            using var context = new EComDbContext();
            var option = new Option();
            var option2 = new Option();
            option2.IsRelease = false;
            context.Add(option);
            context.Add(option2);
            context.AddRange(_users);
            var permissionStrings = CommonLib.GetAdminOperationTypes();
            var permissions = new List<Permission>();
            foreach (var item in permissionStrings)
            {
                permissions.Add(new Permission()
                {
                    IsValid = true,
                    Name = item
                });
            }
            context.AddRange(permissions);
            context.AddRange(_roles);
            context.SaveChanges();
            var rolePermissions = context.Permissions
                .Select(x => x.Id)
                .ToList()
                .Select(x => new RolePermission()
                {
                    PermissionId = x,
                    RoleId = 1
                })
                .ToList();
            context.AddRange(rolePermissions);
            context.SaveChanges();
            context.AddRange(_admins);
            context.SaveChanges();
            context.AddRange(_companyInformations);
            context.SaveChanges();
        }
        static readonly List<CompanyInformation> _companyInformations = new List<CompanyInformation>()
        {
            new CompanyInformation()
            {
                CompanyAddress = "Address",
                CompanyName = "ECom.Company",
                ContactEmail = "contact@support.com",
                Description = "Company Description",
                DomainUrl = "www.company.com",
                FacebookLink = "facebook.com/company",
                InstagramLink = "instagram.com/company",
                IsRelease = true,
                PhoneNumber = "5526667788",
                WebApiUrl = "api.company.com",
                WhatsApp = "5526667788",
                YoutubeLink = "yt.com/company",
            },
            new CompanyInformation()
            {
                CompanyAddress = "Address",
                CompanyName = "ECom.Company",
                ContactEmail = "contact@support.com",
                Description = "Company Description",
                DomainUrl = "www.company.com",
                FacebookLink = "facebook.com/company",
                InstagramLink = "instagram.com/company",
                IsRelease = false,
                PhoneNumber = "5526667788",
                WebApiUrl = "api.company.com",
                WhatsApp = "5526667788",
                YoutubeLink = "yt.com/company",
            },
        };
        static readonly List<User> _users = new List<User>()
        {
            new User()
            {
                EmailAddress = "user@mail.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                IsTestAccount = false,
                Name = "User",
                PhoneNumber = "5525553344",
                TwoFactorType = 0,
                Surname = "Resu"
            },
            new User()
            {
                EmailAddress = "test@mail.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                IsTestAccount = true,
                Name = "User",
                PhoneNumber = "5525553344",
                TwoFactorType = 0,
                Surname = "Resu"
            },
            new User()
            {
                EmailAddress = "qwe@qwe.com",
                Password = Convert.ToBase64String("qweqweqwe".MD5Hash()),
                IsTestAccount = false,
                Name = "User",
                PhoneNumber = "5525553344",
                TwoFactorType = 0,
                Surname = "Resu"
            },
        };
        static readonly List<Admin> _admins = new List<Admin>()
        {
            new Admin()
            {
                EmailAddress = "owner@mail.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                IsTestAccount = false,
                RoleId = 1,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "test@owner.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                IsTestAccount = true,
                RoleId = 1,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "test@admin.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                IsTestAccount = true,
                RoleId = 2,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "test@mod.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                IsTestAccount = true,
                RoleId = 3,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "qwe@qwe.com",
                Password = Convert.ToBase64String("qweqweqwe".MD5Hash()),
                IsTestAccount = true,
                RoleId = 1,
                TwoFactorType = 0
            },
        };
        static readonly List<Role> _roles = new List<Role>()
        {
            new Role()
            {
                IsValid = true,
                Name = "Owner",
            },
            new Role()
            {
                IsValid = true,
                Name = "Admin",
            },
            new Role()
            {
                IsValid = true,
                Name = "Mod",
            },
        };


    }
}
