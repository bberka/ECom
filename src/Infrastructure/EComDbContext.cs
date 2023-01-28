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


    }
}
