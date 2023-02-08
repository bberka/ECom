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
            modelBuilder.Entity<ProductCommentStar>()
                .HasKey(u => new
                {
                    u.UserId,
                    u.CommentId
                });
            modelBuilder.Entity<ProductComment>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductComment>()
                .HasMany(s => s.Stars)
                .WithOne(x => x.Comment)
                .HasForeignKey(x => x.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(s => s.ProductComments)
                .WithOne(x => x.AuthorUser)
                .HasForeignKey(x => x.AuthorUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public static EComDbContext New() => new EComDbContext();
        public static void EnsureCreated()
        {
            var created = new EComDbContext().Database.EnsureCreated();
            if (!created) return;
            BaseDbFiller.Run();
            

        }
        public DbSet<Image> Images { get; set; }

        #region Product-Management
        public DbSet<StockChange> StockChanges { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        #endregion

        #region Product
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<ProductCommentImage> ProductCommentImages { get; set; }
        public DbSet<ProductCommentStar> ProductCommentStars { get; set; }

        #endregion

        #region Discount
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }

        public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        public DbSet<DiscountNotify> DiscountNotifies { get; set; }


        #endregion

        #region Category
        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ProductSubCategory> ProductSubCategories { get; set; }


        #endregion

        #region  Logs

        public DbSet<UserLog> UserLogs { get; set; }
        public DbSet<AdminLog> AdminLogs { get; set; }
        public DbSet<SecurityLog> SecurityLogs { get; set; }

        #endregion

        #region Options
        public DbSet<CompanyInformation> CompanyInformations { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<CargoOption> CargoOptions { get; set; }
        public DbSet<SmtpOption> SmtpOptions { get; set; }
        public DbSet<PaymentOption> PaymentOptions { get; set; }

        #endregion

        #region Admin - Permissions

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        #endregion

        #region HomePage

        public DbSet<Slider> Sliders { get; set; }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<ShowCaseImage> ShowCaseImages { get; set; }

        public DbSet<ProductShowCase> ProductShowCases { get; set; }


        #endregion

        #region User
        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionProduct> CollectionProducts { get; set; }
        public DbSet<Order> Orders { get; set; }


        public DbSet<EmailVerifyToken> EmailVerifyTokens { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

        #endregion




    }
}
