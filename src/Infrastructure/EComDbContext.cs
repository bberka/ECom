using ECom.Infrastructure.Configurations;
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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);

 


        }

        public static EComDbContext New() => new EComDbContext();
        public static void EnsureCreatedAndUpdated()
        {
            var context = new EComDbContext();
            var created = context.Database.EnsureCreated();
            //var missingMigrations = context.Database.GetAppliedMigrations().ToList();
            //if (missingMigrations.Count > 0)
            //{
            //    context.Database.Migrate();
            //}
            if (!created) return;
            BaseDbFiller.Run();
        }
        public DbSet<Image> Images { get; set; }

        public DbSet<StockChange> StockChanges { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }

        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<DiscountNotify> DiscountNotifies { get; set; }


        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }


        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<SecurityLog> SecurityLogs { get; set; }


        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<CargoOption> CargoOptions { get; set; }
        public DbSet<SmtpOption> SmtpOptions { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }




        public DbSet<Admin> Admins { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }



        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<ShowCaseImage> ShowCaseImages { get; set; }
        public DbSet<ProductShowCase> ProductShowCases { get; set; }


        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionProduct> CollectionProducts { get; set; }
        public DbSet<Order> Orders { get; set; }


        public DbSet<EmailVerifyToken> EmailVerifyTokens { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }





    }
}
