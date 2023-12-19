using ECom.Database.Abstract;
using ECom.Foundation.Abstract;

namespace ECom.Database;

public class UnitOfWork : UnitOfWorkBase<EComDbContext>,
                          IUnitOfWork
{
  public UnitOfWork(EComDbContext comDbContext) : base(comDbContext) { }

  public virtual DbSet<Address> Addresses => DbContext.Set<Address>();
  public virtual DbSet<Admin> Admins => DbContext.Set<Admin>();
  public virtual DbSet<AdminLog> AdminLogs => DbContext.Set<AdminLog>();
  public virtual DbSet<Announcement> Announcements => DbContext.Set<Announcement>();
  public virtual DbSet<CargoOption> CargoOptions => DbContext.Set<CargoOption>();
  public virtual DbSet<Cart> Carts => DbContext.Set<Cart>();
  public virtual DbSet<Category> Categories => DbContext.Set<Category>();
  public virtual DbSet<CategoryDiscount> CategoryDiscounts => DbContext.Set<CategoryDiscount>();
  public virtual DbSet<Collection> Collections => DbContext.Set<Collection>();
  public virtual DbSet<CollectionProduct> CollectionProducts => DbContext.Set<CollectionProduct>();
  public virtual DbSet<CompanyInformation> CompanyInformation => DbContext.Set<CompanyInformation>();
  public virtual DbSet<DiscountCoupon> DiscountCoupons => DbContext.Set<DiscountCoupon>();
  public virtual DbSet<DiscountNotify> DiscountNotifies => DbContext.Set<DiscountNotify>();
  public virtual DbSet<EmailVerifyToken> EmailVerifyTokens => DbContext.Set<EmailVerifyToken>();
  public virtual DbSet<FavoriteProduct> FavoriteProducts => DbContext.Set<FavoriteProduct>();
  public virtual DbSet<Image> Images => DbContext.Set<Image>();
  public virtual DbSet<Option> Options => DbContext.Set<Option>();
  public virtual DbSet<Order> Orders => DbContext.Set<Order>();
  public virtual DbSet<PasswordResetToken> PasswordResetTokens => DbContext.Set<PasswordResetToken>();
  public virtual DbSet<PaymentOption> PaymentOptions => DbContext.Set<PaymentOption>();
  public virtual DbSet<Product> Products => DbContext.Set<Product>();
  public virtual DbSet<ProductComment> ProductComments => DbContext.Set<ProductComment>();
  public virtual DbSet<ProductDetail> ProductDetails => DbContext.Set<ProductDetail>();
  public virtual DbSet<ShowCase> ShowCases => DbContext.Set<ShowCase>();
  public virtual DbSet<ProductCategory> ProductCategories => DbContext.Set<ProductCategory>();
  public virtual DbSet<Role> Roles => DbContext.Set<Role>();
  public virtual DbSet<PermissionRole> PermissionRoles => DbContext.Set<PermissionRole>();
  public virtual DbSet<SecurityLog> SecurityLogs => DbContext.Set<SecurityLog>();
  public virtual DbSet<Slider> Sliders => DbContext.Set<Slider>();
  public virtual DbSet<SmtpOption> SmtpOptions => DbContext.Set<SmtpOption>();
  public virtual DbSet<StockChange> StockChanges => DbContext.Set<StockChange>();
  public virtual DbSet<Supplier> Suppliers => DbContext.Set<Supplier>();
  public virtual DbSet<User> Users => DbContext.Set<User>();
  public virtual DbSet<Content> Contents => DbContext.Set<Content>();
  public virtual DbSet<AdminSession> AdminSessions => DbContext.Set<AdminSession>();
  public virtual DbSet<UserSession> UserSessions => DbContext.Set<UserSession>();
  public virtual DbSet<EmailQueue> EmailQueue => DbContext.Set<EmailQueue>();
}