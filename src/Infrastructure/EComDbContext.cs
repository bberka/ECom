using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Infrastructure
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
        public static EComDbContext New() => new EComDbContext();

		public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<EmailVerifyToken> EmailVerifyTokens { get; set; }
        public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionProduct> CollectionProducts { get; set; }
        public DbSet<SmtpOption> SmtpOptions { get; set; }


    }
}
