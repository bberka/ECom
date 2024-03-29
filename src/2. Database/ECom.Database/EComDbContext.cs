﻿using ECom.Database.Configurations;
using ECom.Foundation.Static;
using Microsoft.Extensions.Logging;

namespace ECom.Database;

public class EComDbContext : DbContext
{
  public DbSet<Image> Images { get; set; }

  public DbSet<StockChange> StockChanges { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }

  public DbSet<Product> Products { get; set; }

  public DbSet<ProductDetail> ProductDetails { get; set; }

  public DbSet<ProductImage> ProductImages { get; set; }
  public DbSet<ProductComment> ProductComments { get; set; }
  public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
  public DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
  public DbSet<DiscountNotify> DiscountNotifies { get; set; }

  public DbSet<Category> Categories { get; set; }
  public DbSet<ProductCategory> ProductSubCategories { get; set; }


  public DbSet<AdminLog> AdminLogs { get; set; }
  public DbSet<SecurityLog> SecurityLogs { get; set; }


  public DbSet<CompanyInformation> CompanyInformations { get; set; }
  public DbSet<Option> Options { get; set; }
  public DbSet<CargoOption> CargoOptions { get; set; }
  public DbSet<SmtpOption> SmtpOptions { get; set; }
  public DbSet<PaymentOption> PaymentOptions { get; set; }


  public DbSet<Admin> Admins { get; set; }
  public DbSet<PermissionRole> PermissionRoles { get; set; }
  public DbSet<Role> Roles { get; set; }


  public DbSet<Slider> Sliders { get; set; }
  public DbSet<Announcement> Announcements { get; set; }
  public DbSet<ShowCase> ShowCases { get; set; }

  public DbSet<User> Users { get; set; }
  public DbSet<Cart> Carts { get; set; }
  public DbSet<Address> Addresses { get; set; }
  public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
  public DbSet<Collection> Collections { get; set; }
  public DbSet<CollectionProduct> CollectionProducts { get; set; }
  public DbSet<Order> Orders { get; set; }


  public DbSet<EmailVerifyToken> EmailVerifyTokens { get; set; }
  public DbSet<PasswordResetToken> PasswordResetTokens { get; set; }

  public DbSet<AdminSession> AdminSessions { get; set; }
  public DbSet<UserSession> UserSessions { get; set; }

  public DbSet<Content> Contents { get; set; }

  public DbSet<EmailQueue> EmailQueue { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    optionsBuilder.UseSqlServer(DomAppSettings.This.DatabaseConnectionString);

    optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleConfiguration).Assembly);
  }


  public static void EnsureCreatedAndUpdated() {
    var context = new EComDbContext();
    var created = context.Database.EnsureCreated();
    //if (created) {
    //  context.Database.ExecuteSqlRaw("ALTER DATABASE ECom SET READ_COMMITTED_SNAPSHOT ON;");
    //}
    try {
      context.Database.Migrate();
    }
    catch {
      //ignored
    }

    context.Dispose();
  }
}