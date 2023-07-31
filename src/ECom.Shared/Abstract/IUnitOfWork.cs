using ECom.Shared.Entities;

namespace ECom.Shared.Abstract;

public interface IUnitOfWork : IUnitOfWorkBase
{
  DbSet<Address> AddressRepository { get; }
  DbSet<Admin> AdminRepository { get; }
  DbSet<AdminLog> AdminLogRepository { get; }
  DbSet<Announcement> AnnouncementRepository { get; }
  DbSet<CargoOption> CargoOptionRepository { get; }
  DbSet<Cart> CartRepository { get; }
  DbSet<Category> CategoryRepository { get; }
  DbSet<CategoryDiscount> CategoryDiscountRepository { get; }
  DbSet<Collection> CollectionRepository { get; }
  DbSet<CollectionProduct> CollectionProductRepository { get; }
  DbSet<CompanyInformation> CompanyInformationRepository { get; }
  DbSet<DiscountCoupon> DiscountCouponRepository { get; }
  DbSet<DiscountNotify> DiscountNotifyRepository { get; }
  DbSet<EmailVerifyToken> EmailVerifyTokenRepository { get; }
  DbSet<FavoriteProduct> FavoriteProductRepository { get; }
  DbSet<Image> ImageRepository { get; }
  DbSet<Option> OptionRepository { get; }
  DbSet<Order> OrderRepository { get; }
  DbSet<PasswordResetToken> PasswordResetTokenRepository { get; }
  DbSet<PaymentOption> PaymentOptionRepository { get; }
  DbSet<Permission> PermissionRepository { get; }
  DbSet<Product> ProductRepository { get; }
  DbSet<ProductComment> ProductCommentRepository { get; }
  DbSet<ProductDetail> ProductDetailRepository { get; }
  DbSet<ShowCase> ShowCaseRepository { get; }
  DbSet<ProductCategory> ProductCategoryRepository { get; }
  DbSet<ProductVariant> ProductVariantRepository { get; }
  DbSet<Role> RoleRepository { get; }
  DbSet<SecurityLog> SecurityLogRepository { get; }
  DbSet<Slider> SliderRepository { get; }
  DbSet<SmtpOption> SmtpOptionRepository { get; }
  DbSet<StockChange> StockChangeRepository { get; }
  DbSet<Supplier> SupplierRepository { get; }
  DbSet<User> UserRepository { get; }

}