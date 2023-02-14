using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        bool Save();
        Task<bool> SaveAsync();

        IEntityRepository<Address> AddressRepository { get; }
        IEntityRepository<Admin> AdminRepository { get; }
        IEntityRepository<AdminLog> AdminLogRepository { get; }
        IEntityRepository<Announcement> AnnouncementRepository { get; }
        IEntityRepository<CargoOption> CargoOptionRepository { get; }
        IEntityRepository<Cart> CartRepository { get; }
        IEntityRepository<Category> CategoryRepository { get; }
        IEntityRepository<CategoryDiscount> CategoryDiscountRepository { get; }
        IEntityRepository<Collection> CollectionRepository { get; }
        IEntityRepository<CollectionProduct> CollectionProductRepository { get; }
        IEntityRepository<CompanyInformation> CompanyInformationRepository { get; }
        IEntityRepository<DiscountCoupon> DiscountCouponRepository { get; }
        IEntityRepository<DiscountNotify> DiscountNotifyRepository { get; }
        IEntityRepository<EmailVerifyToken> EmailVerifyTokenRepository { get; }
        IEntityRepository<FavoriteProduct> FavoriteProductRepository { get; }
        IEntityRepository<Image> ImageRepository { get; }
        IEntityRepository<Option> OptionRepository { get; }
        IEntityRepository<Order> OrderRepository { get; }
        IEntityRepository<PasswordResetToken> PasswordResetTokenRepository { get; }
        IEntityRepository<PaymentOption> PaymentOptionRepository { get; }
        IEntityRepository<Permission> PermissionRepository { get; }
        IEntityRepository<Product> ProductRepository { get; }
        IEntityRepository<ProductComment> ProductCommentRepository { get; }
        IEntityRepository<ProductDetail> ProductDetailRepository { get; }
        //IEntityRepository<ProductImage> ProductImageRepository { get; }
        IEntityRepository<ProductShowCase> ProductShowCaseRepository { get; }
        IEntityRepository<ProductSubCategory> ProductSubCategoryRepository { get; }
        IEntityRepository<ProductVariant> ProductVariantRepository { get; }
        IEntityRepository<Role> RoleRepository { get; }
        //IEntityRepository<PermissionRole> RolePermissionRepository { get; }
        IEntityRepository<SecurityLog> SecurityLogRepository { get; }
        IEntityRepository<ShowCaseImage> ShowCaseImageRepository { get; }
        IEntityRepository<Slider> SliderRepository { get; }
        IEntityRepository<SmtpOption> SmtpOptionRepository { get; }
        IEntityRepository<StockChange> StockChangeRepository { get; }
        IEntityRepository<SubCategory> SubCategoryRepository { get; }
        IEntityRepository<Supplier> SupplierRepository { get; }
        IEntityRepository<User> UserRepository { get; }
        IEntityRepository<UserLog> UserLogRepository { get; }

    }
}