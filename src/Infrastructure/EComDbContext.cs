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
			modelBuilder.Entity<ProductImageBind>()
                .HasKey(u => new
			{
				u.ProductId,
				u.ImageId
			});
		}

		public static EComDbContext New() => new EComDbContext();
        public static void EnsureCreated()
        {
            var created = new EComDbContext().Database.EnsureCreated();
            if (!created) return;
            using var context = new EComDbContext();
            context.Database.Migrate();
            var role = new Role
            {
                IsValid = true,
                Memo = "Initial",
                Name = "Initial",
            };
            context.Add(role);
            var perm = new Permission
            {
                IsValid = true,
                Name = "Initial",
                Memo = "Test",
            };
            context.Add(perm);
            var roleBind = new RoleBind
            {
                PermissionId = 1,
                RoleId = 1,
            };
            context.Add(roleBind);
            var testUser = new User
            {
                CitizenShipNumber = 1,
                DeletedDate = null,
                EmailAddress = "qwe@qwe",
                FailedPasswordCount = 0,
                IsEmailVerified = true,
                IsTestAccount = true,
                IsValid = true,
                LastLoginDate = DateTime.Now,
                LastLoginIp = "127.0.0.1",
                LastLoginUserAgent = "",
                Name = "String",
                Password = Convert.ToBase64String("qwe".MD5Hash()),
                PhoneNumber = "5526667788",
                PreferredLanguageId = 1,
                RegisterDate = DateTime.Now,
                Surname = "Str",
                TotalLoginCount = 0,
                PasswordLastUpdateDate = DateTime.Now,
                TaxNumber = 0,
            };
            context.Add(testUser);
            var testAdmin = new Admin
            {
                DeletedDate = null,
                EmailAddress = "qwe@qwe",
                FailedPasswordCount = 0,
                IsTestAccount = true,
                IsValid = true,
                LastLoginDate = DateTime.Now,
                LastLoginIp = "127.0.0.1",
                LastLoginUserAgent = "",
                Password = Convert.ToBase64String("qwe".MD5Hash()),
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
        public DbSet<ProductImageBind> ProductImageBinds { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductCommentImageBind> ProductCommentImageBinds { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<SecurityLog> SecurityLogs { get; set; }
        public DbSet<CargoOption> CargoOptions { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RoleBind> RoleBinds { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<JwtOption> JwtOptions { get; set; }
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
    }
}
