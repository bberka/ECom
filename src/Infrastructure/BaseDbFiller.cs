namespace ECom.Infrastructure
{
    internal static class BaseDbFiller
    {

        internal static void Run()
        {
            using var context = new EComDbContext();
            var option = new Option();
            option.IsRelease = !ConstantMgr.IsDebug();
            context.Add(option);
            context.AddRange(_users);
           
            context.AddRange(_roles);
            context.AddRange(_admins);
            context.SaveChanges();
            foreach (var role in _roles)
            {
                if (role.Id != 1) continue;
                var permList = CommonLib.GetAdminOperationTypes();
                role.Permissions = new();
                for (int i = 1; i < permList.Length; i++)
                {
                    var name = permList[i];
                    role.Permissions.Add(new Permission()
                    {
                        IsValid = true,
                        Name = name,
                    });
                }
            }
            context.Update(_roles);
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
                FirstName = "User",
                PhoneNumber = "5525553344",
                TwoFactorType = 0,
                LastName = "Resu"
            },
            new User()
            {
                EmailAddress = "test@mail.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                FirstName = "User",
                PhoneNumber = "5525553344",
                TwoFactorType = 0,
                LastName = "Resu"
            },
            new User()
            {
                EmailAddress = "qwe@qwe.com",
                Password = Convert.ToBase64String("qweqweqwe".MD5Hash()),
                FirstName = "User",
                PhoneNumber = "5525553344",
                TwoFactorType = 0,
                LastName = "Resu"
            },
        };
        
        private static List<Role> _roles = new()
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
                Name = "Moderator",
            },
        };
            static readonly List<Admin> _admins = new List<Admin>()
        {
            new Admin()
            {
                EmailAddress = "owner@mail.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                RoleId = 1,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "test@owner.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                RoleId = 1,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "test@admin.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                RoleId = 2,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "test@mod.com",
                Password = Convert.ToBase64String("123456789".MD5Hash()),
                RoleId = 3,
                TwoFactorType = 0
            },
            new Admin()
            {
                EmailAddress = "qwe@qwe.com",
                Password = Convert.ToBase64String("qweqweqwe".MD5Hash()),
                RoleId = 1,
                TwoFactorType = 0
            },
        };
      

    }
}
