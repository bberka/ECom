using ECom.Foundation.Entities;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECom.Foundation.Abstract;

public interface IUnitOfWork : IDisposable
{
  DbSet<Address> Addresses { get; }
  DbSet<Admin> Admins { get; }
  DbSet<AdminLog> AdminLogs { get; }
  DbSet<Announcement> Announcements { get; }
  DbSet<CargoOption> CargoOptions { get; }
  DbSet<Cart> Carts { get; }
  DbSet<Category> Categories { get; }
  DbSet<CategoryDiscount> CategoryDiscounts { get; }
  DbSet<Collection> Collections { get; }
  DbSet<CollectionProduct> CollectionProducts { get; }
  DbSet<CompanyInformation> CompanyInformation { get; }
  DbSet<DiscountCoupon> DiscountCoupons { get; }
  DbSet<DiscountNotify> DiscountNotifies { get; }
  DbSet<EmailVerifyToken> EmailVerifyTokens { get; }
  DbSet<FavoriteProduct> FavoriteProducts { get; }
  DbSet<Image> Images { get; }
  DbSet<Option> Options { get; }
  DbSet<Order> Orders { get; }
  DbSet<PasswordResetToken> PasswordResetTokens { get; }
  DbSet<PaymentOption> PaymentOptions { get; }

  DbSet<Product> Products { get; }
  DbSet<ProductComment> ProductComments { get; }
  DbSet<ProductDetail> ProductDetails { get; }
  DbSet<ShowCase> ShowCases { get; }
  DbSet<ProductCategory> ProductCategories { get; }
  DbSet<Role> Roles { get; }
  DbSet<PermissionRole> PermissionRoles { get; }
  DbSet<SecurityLog> SecurityLogs { get; }
  DbSet<Slider> Sliders { get; }
  DbSet<SmtpOption> SmtpOptions { get; }
  DbSet<StockChange> StockChanges { get; }
  DbSet<Supplier> Suppliers { get; }
  DbSet<User> Users { get; }
  DbSet<Content> Contents { get; }
  DbSet<AdminSession> AdminSessions { get; }
  DbSet<UserSession> UserSessions { get; }
  DbSet<EmailQueue> EmailQueue { get; }
  bool Save();
  Task<bool> SaveAsync();
  int SaveChanges();
  Task<int> SaveChangesAsync();
  void Dispose();
  IDbContextTransaction BeginTransaction();
  Task<IDbContextTransaction> BeginTransactionAsync();
}