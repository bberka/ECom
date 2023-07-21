using EasMe.EntityFrameworkCore;
using ECom.Domain.Entities;

namespace ECom.Domain.Abstract;

public interface IUnitOfWork : IDisposable
{
  IGenericRepository<Address> AddressRepository { get; }
  IGenericRepository<Admin> AdminRepository { get; }
  IGenericRepository<AdminLog> AdminLogRepository { get; }
  IGenericRepository<Announcement> AnnouncementRepository { get; }
  IGenericRepository<CargoOption> CargoOptionRepository { get; }
  IGenericRepository<Cart> CartRepository { get; }
  IGenericRepository<Category> CategoryRepository { get; }
  IGenericRepository<CategoryDiscount> CategoryDiscountRepository { get; }
  IGenericRepository<Collection> CollectionRepository { get; }
  IGenericRepository<CollectionProduct> CollectionProductRepository { get; }
  IGenericRepository<CompanyInformation> CompanyInformationRepository { get; }
  IGenericRepository<DiscountCoupon> DiscountCouponRepository { get; }
  IGenericRepository<DiscountNotify> DiscountNotifyRepository { get; }
  IGenericRepository<EmailVerifyToken> EmailVerifyTokenRepository { get; }
  IGenericRepository<FavoriteProduct> FavoriteProductRepository { get; }
  IGenericRepository<Image> ImageRepository { get; }
  IGenericRepository<Option> OptionRepository { get; }
  IGenericRepository<Order> OrderRepository { get; }
  IGenericRepository<PasswordResetToken> PasswordResetTokenRepository { get; }
  IGenericRepository<PaymentOption> PaymentOptionRepository { get; }
  IGenericRepository<Permission> PermissionRepository { get; }
  IGenericRepository<Product> ProductRepository { get; }
  IGenericRepository<ProductComment> ProductCommentRepository { get; }
  IGenericRepository<ProductDetail> ProductDetailRepository { get; }
  IGenericRepository<ShowCase> ShowCaseRepository { get; }
  IGenericRepository<ProductCategory> ProductCategoryRepository { get; }
  IGenericRepository<ProductVariant> ProductVariantRepository { get; }
  IGenericRepository<Role> RoleRepository { get; }
  IGenericRepository<PermissionRole> PermissionRoleRepository { get; }
  IGenericRepository<SecurityLog> SecurityLogRepository { get; }
  IGenericRepository<Slider> SliderRepository { get; }
  IGenericRepository<SmtpOption> SmtpOptionRepository { get; }
  IGenericRepository<StockChange> StockChangeRepository { get; }

  //IGenericRepository<SubCategory> SubCategoryRepository { get; }
  IGenericRepository<Supplier> SupplierRepository { get; }
  IGenericRepository<User> UserRepository { get; }
  bool Save();
  Task<bool> SaveAsync();
}