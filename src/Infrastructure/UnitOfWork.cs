using ECom.Infrastructure.Abstract;
using ECom.Infrastructure.Repository;
using ECom.Shared.Abstract;
using ECom.Shared.Entities;
using Serilog;

namespace ECom.Infrastructure;

public class UnitOfWork : UnitOfWorkBase<EComDbContext>, IUnitOfWork
{
  public UnitOfWork(EComDbContext comDbContext) : base(comDbContext) {

  }

  public virtual DbSet<Address> AddressRepository => DbContext.Set<Address>();
  public virtual DbSet<Admin> AdminRepository => DbContext.Set<Admin>();
  public virtual DbSet<AdminLog> AdminLogRepository => DbContext.Set<AdminLog>();
  public virtual DbSet<Announcement> AnnouncementRepository => DbContext.Set<Announcement>();
  public virtual DbSet<CargoOption> CargoOptionRepository => DbContext.Set<CargoOption>();
  public virtual DbSet<Cart> CartRepository => DbContext.Set<Cart>();
  public virtual DbSet<Category> CategoryRepository => DbContext.Set<Category>();
  public virtual DbSet<CategoryDiscount> CategoryDiscountRepository => DbContext.Set<CategoryDiscount>();
  public virtual DbSet<Collection> CollectionRepository => DbContext.Set<Collection>();
  public virtual DbSet<CollectionProduct> CollectionProductRepository => DbContext.Set<CollectionProduct>();
  public virtual DbSet<CompanyInformation> CompanyInformationRepository => DbContext.Set<CompanyInformation>();
  public virtual DbSet<DiscountCoupon> DiscountCouponRepository => DbContext.Set<DiscountCoupon>();
  public virtual DbSet<DiscountNotify> DiscountNotifyRepository => DbContext.Set<DiscountNotify>();
  public virtual DbSet<EmailVerifyToken> EmailVerifyTokenRepository => DbContext.Set<EmailVerifyToken>();
  public virtual DbSet<FavoriteProduct> FavoriteProductRepository => DbContext.Set<FavoriteProduct>();
  public virtual DbSet<Image> ImageRepository => DbContext.Set<Image>();
  public virtual DbSet<Option> OptionRepository => DbContext.Set<Option>();
  public virtual DbSet<Order> OrderRepository => DbContext.Set<Order>();
  public virtual DbSet<PasswordResetToken> PasswordResetTokenRepository => DbContext.Set<PasswordResetToken>();
  public virtual DbSet<PaymentOption> PaymentOptionRepository => DbContext.Set<PaymentOption>();
  public virtual DbSet<Permission> PermissionRepository => DbContext.Set<Permission>();
  public virtual DbSet<Product> ProductRepository => DbContext.Set<Product>();
  public virtual DbSet<ProductComment> ProductCommentRepository => DbContext.Set<ProductComment>();
  public virtual DbSet<ProductDetail> ProductDetailRepository => DbContext.Set<ProductDetail>();
  public virtual DbSet<ShowCase> ShowCaseRepository => DbContext.Set<ShowCase>();
  public virtual DbSet<ProductCategory> ProductCategoryRepository => DbContext.Set<ProductCategory>();
  public virtual DbSet<ProductVariant> ProductVariantRepository => DbContext.Set<ProductVariant>();
  public virtual DbSet<Role> RoleRepository => DbContext.Set<Role>();
  public virtual DbSet<SecurityLog> SecurityLogRepository => DbContext.Set<SecurityLog>();
  public virtual DbSet<Slider> SliderRepository => DbContext.Set<Slider>();
  public virtual DbSet<SmtpOption> SmtpOptionRepository => DbContext.Set<SmtpOption>();
  public virtual DbSet<StockChange> StockChangeRepository => DbContext.Set<StockChange>();
  public virtual DbSet<Supplier> SupplierRepository => DbContext.Set<Supplier>();
  public virtual DbSet<User> UserRepository => DbContext.Set<User>();
}