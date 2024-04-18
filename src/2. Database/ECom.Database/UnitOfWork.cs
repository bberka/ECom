using ECom.Database.Abstract;
using ECom.Foundation.Abstract;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECom.Database;

public class UnitOfWork : IUnitOfWork
{
  private readonly EComDbContext _dbContext;

  public UnitOfWork(EComDbContext dbContext) {
    _dbContext = dbContext;
  }

  public virtual DbSet<Address> Addresses => _dbContext.Set<Address>();
  public virtual DbSet<Admin> Admins => _dbContext.Set<Admin>();
  public virtual DbSet<AdminLog> AdminLogs => _dbContext.Set<AdminLog>();
  public virtual DbSet<Announcement> Announcements => _dbContext.Set<Announcement>();
  public virtual DbSet<CargoOption> CargoOptions => _dbContext.Set<CargoOption>();
  public virtual DbSet<Cart> Carts => _dbContext.Set<Cart>();
  public virtual DbSet<Category> Categories => _dbContext.Set<Category>();
  public virtual DbSet<CategoryDiscount> CategoryDiscounts => _dbContext.Set<CategoryDiscount>();
  public virtual DbSet<Collection> Collections => _dbContext.Set<Collection>();
  public virtual DbSet<CollectionProduct> CollectionProducts => _dbContext.Set<CollectionProduct>();
  public virtual DbSet<CompanyInformation> CompanyInformation => _dbContext.Set<CompanyInformation>();
  public virtual DbSet<DiscountCoupon> DiscountCoupons => _dbContext.Set<DiscountCoupon>();
  public virtual DbSet<DiscountNotify> DiscountNotifies => _dbContext.Set<DiscountNotify>();
  public virtual DbSet<EmailVerifyToken> EmailVerifyTokens => _dbContext.Set<EmailVerifyToken>();
  public virtual DbSet<FavoriteProduct> FavoriteProducts => _dbContext.Set<FavoriteProduct>();
  public virtual DbSet<Image> Images => _dbContext.Set<Image>();
  public virtual DbSet<Option> Options => _dbContext.Set<Option>();
  public virtual DbSet<Order> Orders => _dbContext.Set<Order>();
  public virtual DbSet<PasswordResetToken> PasswordResetTokens => _dbContext.Set<PasswordResetToken>();
  public virtual DbSet<PaymentOption> PaymentOptions => _dbContext.Set<PaymentOption>();
  public virtual DbSet<Product> Products => _dbContext.Set<Product>();
  public virtual DbSet<ProductComment> ProductComments => _dbContext.Set<ProductComment>();
  public virtual DbSet<ProductDetail> ProductDetails => _dbContext.Set<ProductDetail>();
  public virtual DbSet<ShowCase> ShowCases => _dbContext.Set<ShowCase>();
  public virtual DbSet<ProductCategory> ProductCategories => _dbContext.Set<ProductCategory>();
  public virtual DbSet<Role> Roles => _dbContext.Set<Role>();
  public virtual DbSet<PermissionRole> PermissionRoles => _dbContext.Set<PermissionRole>();
  public virtual DbSet<SecurityLog> SecurityLogs => _dbContext.Set<SecurityLog>();
  public virtual DbSet<Slider> Sliders => _dbContext.Set<Slider>();
  public virtual DbSet<SmtpOption> SmtpOptions => _dbContext.Set<SmtpOption>();
  public virtual DbSet<StockChange> StockChanges => _dbContext.Set<StockChange>();
  public virtual DbSet<Supplier> Suppliers => _dbContext.Set<Supplier>();
  public virtual DbSet<User> Users => _dbContext.Set<User>();
  public virtual DbSet<Content> Contents => _dbContext.Set<Content>();
  public virtual DbSet<AdminSession> AdminSessions => _dbContext.Set<AdminSession>();
  public virtual DbSet<UserSession> UserSessions => _dbContext.Set<UserSession>();
  public virtual DbSet<EmailQueue> EmailQueue => _dbContext.Set<EmailQueue>();


  public virtual bool Save() {
    return _dbContext.SaveChanges() > 0;
  }

  public virtual async Task<bool> SaveAsync() {
    return await _dbContext.SaveChangesAsync() > 0;
  }


  public virtual int SaveChanges() {
    return _dbContext.SaveChanges();
  }

  public virtual async Task<int> SaveChangesAsync() {
    return await _dbContext.SaveChangesAsync();
  }

  public virtual void Dispose() {
    _dbContext.Dispose();
    GC.SuppressFinalize(this);
  }

  public virtual IDbContextTransaction BeginTransaction() {
    return _dbContext.Database.BeginTransaction();
  }

  public virtual async Task<IDbContextTransaction> BeginTransactionAsync() {
    return await _dbContext.Database.BeginTransactionAsync();
  }
}