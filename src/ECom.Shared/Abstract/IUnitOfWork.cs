using ECom.Shared.Entities;

namespace ECom.Shared.Abstract;

public interface IUnitOfWork : IUnitOfWorkBase
{
  IRepository<Address> AddressRepository { get; }
  IRepository<Admin> AdminRepository { get; }
  IRepository<AdminLog> AdminLogRepository { get; }
  IRepository<Announcement> AnnouncementRepository { get; }
  IRepository<CargoOption> CargoOptionRepository { get; }
  IRepository<Cart> CartRepository { get; }
  IRepository<Category> CategoryRepository { get; }
  IRepository<CategoryDiscount> CategoryDiscountRepository { get; }
  IRepository<Collection> CollectionRepository { get; }
  IRepository<CollectionProduct> CollectionProductRepository { get; }
  IRepository<CompanyInformation> CompanyInformationRepository { get; }
  IRepository<DiscountCoupon> DiscountCouponRepository { get; }
  IRepository<DiscountNotify> DiscountNotifyRepository { get; }
  IRepository<EmailVerifyToken> EmailVerifyTokenRepository { get; }
  IRepository<FavoriteProduct> FavoriteProductRepository { get; }
  IRepository<Image> ImageRepository { get; }
  IRepository<Option> OptionRepository { get; }
  IRepository<Order> OrderRepository { get; }
  IRepository<PasswordResetToken> PasswordResetTokenRepository { get; }
  IRepository<PaymentOption> PaymentOptionRepository { get; }
  IRepository<Permission> PermissionRepository { get; }
  IRepository<Product> ProductRepository { get; }
  IRepository<ProductComment> ProductCommentRepository { get; }
  IRepository<ProductDetail> ProductDetailRepository { get; }
  IRepository<ShowCase> ShowCaseRepository { get; }
  IRepository<ProductCategory> ProductCategoryRepository { get; }
  IRepository<ProductVariant> ProductVariantRepository { get; }
  IRepository<Role> RoleRepository { get; }
  IRepository<PermissionRole> PermissionRoleRepository { get; }
  IRepository<SecurityLog> SecurityLogRepository { get; }
  IRepository<Slider> SliderRepository { get; }
  IRepository<SmtpOption> SmtpOptionRepository { get; }
  IRepository<StockChange> StockChangeRepository { get; }
  IRepository<Supplier> SupplierRepository { get; }
  IRepository<User> UserRepository { get; }

}