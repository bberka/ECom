using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace ECom.Infrastructure
{
    public class EComDbContext : DbContext
    {
        public EComDbContext() : base()
        {
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["EComDB"].ConnectionString);
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ProductImage>()
                .HasKey(u => new
			{
				u.ProductId,
				u.ImageId
			});
            modelBuilder.Entity<ImageLanguage>()
                .HasKey(u => new
                {
                    u.Culture,
                    u.ImageId
                });
            modelBuilder.Entity<Cart>()
                .HasKey(u => new
                {
                    u.UserId,
                    u.ProductId
                });
            modelBuilder.Entity<CollectionProduct>()
                .HasKey(u => new
                {
                    u.CollectionId,
                    u.ProductId
                });
            modelBuilder.Entity<DiscountNotify>()
                .HasKey(u => new
                {
                    u.UserId,
                    u.ProductId
                });
            modelBuilder.Entity<FavoriteProduct>()
                .HasKey(u => new
                {
                    u.UserId,
                    u.ProductId
                });
            modelBuilder.Entity<ProductCommentImage>()
                .HasKey(u => new
                {
                    u.ImageId,
                    u.CommentId
                });
            modelBuilder.Entity<RolePermission>()
                .HasKey(u => new
                {
                    u.PermissionId,
                    u.RoleId
                });
            modelBuilder.Entity<ProductSubCategory>()
                .HasKey(u => new
                {
                    u.ProductId,
                    u.SubCategoryId
                });
        }

		public static EComDbContext New() => new EComDbContext();
        public static void EnsureCreated()
        {
            var created = new EComDbContext().Database.EnsureCreated();
            if (!created) return;
            using var context = new EComDbContext();
            var option = new Option();
            option.IsRelease = !ConstantMgr.IsDebug();
            context.Add(option);
            context.SaveChanges();
            var lang = new Language
            {
                Culture = "en",
            };
            var lang2 = new Language
            {
                Culture = "tr",
            };
            context.Add(lang);
            context.Add(lang2);
            context.SaveChanges();
            var role = new Role
            {
                IsValid = true,
                Memo = "Initial-Create-Owner",
                Name = "Owner",
            };
            context.Add(role);
            var perms = new List<Permission>
            {
                new Permission
            {
                IsValid = true,
                Name = "Get",
                Memo = "Initial-Create",
            },
                new Permission
            {
                IsValid = true,
                Name = "Create",
                Memo = "Initial-Create",
            },
                new Permission
            {
                IsValid = true,
                Name = "Update",
                Memo = "Initial-Create",
            },
                new Permission
            {
                IsValid = true,
                Name = "Delete",
                Memo = "Initial-Create",
            }
            };
            context.AddRange(perms);
            context.SaveChanges();

            var roleBind = new RolePermission
            {
                PermissionId = 1,
                RoleId = 1,
            };
            context.Add(roleBind);
            context.SaveChanges();
            var testUser = new User
            {
                CitizenShipNumber = 1,
                DeletedDate = null,
                EmailAddress = "string@string.com",
                FailedPasswordCount = 0,
                IsEmailVerified = true,
                IsTestAccount = true,
                IsValid = true,
                LastLoginDate = DateTime.Now,
                LastLoginIp = "127.0.0.1",
                LastLoginUserAgent = "",
                Name = "String",
                Password = Convert.ToBase64String("string".MD5Hash()),
                PhoneNumber = "5526667788",
                Culture = "en",
                RegisterDate = DateTime.Now,
                Surname = "Str",
                TotalLoginCount = 0,
                PasswordLastUpdateDate = DateTime.Now,
                TaxNumber = 0,
            };
            context.Add(testUser);
            context.SaveChanges();

            var testAdmin = new Admin
            {
                DeletedDate = null,
                EmailAddress = "string@string.com",
                FailedPasswordCount = 0,
                IsTestAccount = true,
                IsValid = true,
                LastLoginDate = DateTime.Now,
                LastLoginIp = "127.0.0.1",
                LastLoginUserAgent = "",
                Password = Convert.ToBase64String("string".MD5Hash()),
                RegisterDate = DateTime.Now,
                TotalLoginCount = 0,
                PasswordLastUpdateDate = DateTime.Now,
                RoleId =1,
            };
            context.Add(testAdmin);
            context.SaveChanges();

          

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<EmailVerifyToken> EmailVerifyTokens { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionProduct> CollectionProducts { get; set; }
        public DbSet<SmtpOption> SmtpOptions { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<DiscountNotify> DiscountNotifies { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductCommentImage> ProductCommentImages { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<SecurityLog> SecurityLogs { get; set; }
        public DbSet<CargoOption> CargoOptions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<ImageLanguage> ImageLanguages { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<StockChange> StockChanges { get; set; }
    }
}
