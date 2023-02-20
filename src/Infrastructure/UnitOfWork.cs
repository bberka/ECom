

namespace ECom.Infrastructure;

//IEntityRepository<Address> addressRepository,
//IEntityRepository<Admin> adminRepository,
//IEntityRepository<AdminLog> adminLogRepository,
//IEntityRepository<Announcement> announcementRepository,
//IEntityRepository<CargoOption> cargoOptionRepository,
//IEntityRepository<Cart> cartRepository,
//IEntityRepository<Category> categoryRepository,
//IEntityRepository<CategoryDiscount> categoryDiscountRepository,
//IEntityRepository<Collection> collectionRepository,
//IEntityRepository<CollectionProduct> collectionProductRepository,
//IEntityRepository<CompanyInformation> companyInformationRepository,
//IEntityRepository<DiscountCoupon> discountCouponRepository,
//IEntityRepository<DiscountNotify> discountNotifyRepository,
//IEntityRepository<EmailVerifyToken> emailVerifyTokenRepository,
//IEntityRepository<FavoriteProduct> favoriteProductRepository,
//IEntityRepository<Image> imageRepository,
//IEntityRepository<Option> optionRepository,
//IEntityRepository<Order> orderRepository,
//IEntityRepository<PasswordResetToken> passwordResetTokenRepository,
//IEntityRepository<PaymentOption> paymentOptionRepository,
//IEntityRepository<Permission> permissionRepository,
//IEntityRepository<Product> productRepository,
//IEntityRepository<ProductComment> productCommentRepository,
//IEntityRepository<ProductDetail> productDetailRepository,
//IEntityRepository<ProductImage> productImageRepository,

public class UnitOfWork : IUnitOfWork
{
    private readonly EComDbContext _dbContext;
    private bool _disposed;
    public UnitOfWork()
    {
        _disposed = false;
        _dbContext = new EComDbContext();
        AddressRepository = new EntityRepositoryBase<Address,EComDbContext>(_dbContext);
        AdminRepository = new EntityRepositoryBase<Admin, EComDbContext>(_dbContext);
        AdminLogRepository = new EntityRepositoryBase<AdminLog, EComDbContext>(_dbContext);
        AnnouncementRepository = new EntityRepositoryBase<Announcement, EComDbContext>(_dbContext);
        CargoOptionRepository = new EntityRepositoryBase<CargoOption, EComDbContext>(_dbContext);
        CartRepository = new EntityRepositoryBase<Cart, EComDbContext>(_dbContext);
        CategoryRepository = new EntityRepositoryBase<Category,EComDbContext>(_dbContext);
        CategoryDiscountRepository = new EntityRepositoryBase<CategoryDiscount,EComDbContext>(_dbContext);
        CollectionRepository = new EntityRepositoryBase<Collection,EComDbContext>(_dbContext);
        CollectionProductRepository = new EntityRepositoryBase<CollectionProduct,EComDbContext>(_dbContext);
        CompanyInformationRepository = new EntityRepositoryBase<CompanyInformation,EComDbContext>(_dbContext);
        DiscountCouponRepository = new EntityRepositoryBase<DiscountCoupon,EComDbContext>(_dbContext);
        DiscountNotifyRepository = new EntityRepositoryBase<DiscountNotify,EComDbContext>(_dbContext);
        EmailVerifyTokenRepository = new EntityRepositoryBase<EmailVerifyToken,EComDbContext>(_dbContext);
        FavoriteProductRepository = new EntityRepositoryBase<FavoriteProduct,EComDbContext>(_dbContext);
        ImageRepository = new EntityRepositoryBase<Image,EComDbContext>(_dbContext);
        OptionRepository = new EntityRepositoryBase<Option,EComDbContext>(_dbContext);
        OrderRepository = new EntityRepositoryBase<Order,EComDbContext>(_dbContext);
        PasswordResetTokenRepository = new EntityRepositoryBase<PasswordResetToken,EComDbContext>(_dbContext);
        PaymentOptionRepository = new EntityRepositoryBase<PaymentOption,EComDbContext>(_dbContext);
        PermissionRepository = new EntityRepositoryBase<Permission,EComDbContext>(_dbContext);
        ProductRepository = new EntityRepositoryBase<Product,EComDbContext>(_dbContext);
        ProductCommentRepository = new EntityRepositoryBase<ProductComment,EComDbContext>(_dbContext);
        ProductDetailRepository = new EntityRepositoryBase<ProductDetail,EComDbContext>(_dbContext);
        //ProductImageRepository = new EntityRepositoryBase<ProductImage,EComDbContext>(_dbContext);
        ProductShowCaseRepository = new EntityRepositoryBase<ProductShowCase, EComDbContext>(_dbContext);
        ProductSubCategoryRepository = new EntityRepositoryBase<ProductSubCategory, EComDbContext>(_dbContext);
        ProductVariantRepository = new EntityRepositoryBase<ProductVariant, EComDbContext>(_dbContext);
        RoleRepository = new EntityRepositoryBase<Role, EComDbContext>(_dbContext);
        PermissionRoleRepository = new EntityRepositoryBase<PermissionRole, EComDbContext>(_dbContext);
        SecurityLogRepository = new EntityRepositoryBase<SecurityLog, EComDbContext>(_dbContext);
        ShowCaseImageRepository = new EntityRepositoryBase<ShowCaseImage, EComDbContext>(_dbContext);
        SliderRepository = new EntityRepositoryBase<Slider, EComDbContext>(_dbContext);
        SmtpOptionRepository = new EntityRepositoryBase<SmtpOption, EComDbContext>(_dbContext);
        StockChangeRepository = new EntityRepositoryBase<StockChange, EComDbContext>(_dbContext);
        SubCategoryRepository = new EntityRepositoryBase<SubCategory, EComDbContext>(_dbContext);
        SupplierRepository = new EntityRepositoryBase<Supplier, EComDbContext>(_dbContext);
        UserRepository = new EntityRepositoryBase<User, EComDbContext>(_dbContext);
        UserLogRepository = new EntityRepositoryBase<UserLog, EComDbContext>(_dbContext);
    }

    public IEntityRepository<Address> AddressRepository { get; }
    public IEntityRepository<Admin> AdminRepository { get; }
    public IEntityRepository<AdminLog> AdminLogRepository { get; }
    public IEntityRepository<Announcement> AnnouncementRepository { get; }
    public IEntityRepository<CargoOption> CargoOptionRepository { get; }
    public IEntityRepository<Cart> CartRepository { get; }
    public IEntityRepository<Category> CategoryRepository { get; }
    public IEntityRepository<CategoryDiscount> CategoryDiscountRepository { get; }
    public IEntityRepository<Collection> CollectionRepository { get; }
    public IEntityRepository<CollectionProduct> CollectionProductRepository { get; }
    public IEntityRepository<CompanyInformation> CompanyInformationRepository { get; }
    public IEntityRepository<DiscountCoupon> DiscountCouponRepository { get; }
    public IEntityRepository<DiscountNotify> DiscountNotifyRepository { get; }
    public IEntityRepository<EmailVerifyToken> EmailVerifyTokenRepository { get; }
    public IEntityRepository<FavoriteProduct> FavoriteProductRepository { get; }
    public IEntityRepository<Image> ImageRepository { get; }
    public IEntityRepository<Option> OptionRepository { get; }
    public IEntityRepository<Order> OrderRepository { get; }
    public IEntityRepository<PasswordResetToken> PasswordResetTokenRepository { get; }
    public IEntityRepository<PaymentOption> PaymentOptionRepository { get; }
    public IEntityRepository<Permission> PermissionRepository { get; }
    public IEntityRepository<Product> ProductRepository { get; }
    public IEntityRepository<ProductComment> ProductCommentRepository { get; }
    public IEntityRepository<ProductDetail> ProductDetailRepository { get; }
    //public IEntityRepository<ProductImage> ProductImageRepository { get; }
    public IEntityRepository<ProductShowCase> ProductShowCaseRepository { get; }
    public IEntityRepository<ProductSubCategory> ProductSubCategoryRepository { get; }
    public IEntityRepository<ProductVariant> ProductVariantRepository { get; }
    public IEntityRepository<Role> RoleRepository { get; }
    public IEntityRepository<PermissionRole> PermissionRoleRepository { get; }
    public IEntityRepository<SecurityLog> SecurityLogRepository { get; }
    public IEntityRepository<ShowCaseImage> ShowCaseImageRepository { get; }
    public IEntityRepository<Slider> SliderRepository { get; }
    public IEntityRepository<SmtpOption> SmtpOptionRepository { get; }
    public IEntityRepository<StockChange> StockChangeRepository { get; }
    public IEntityRepository<SubCategory> SubCategoryRepository { get; }
    public IEntityRepository<Supplier> SupplierRepository { get; }
    public IEntityRepository<User> UserRepository { get; }
    public IEntityRepository<UserLog> UserLogRepository { get; }


    public bool Save()
    {
        using var transaction = _dbContext.Database.BeginTransaction();
        try
        {
            var affected = _dbContext.SaveChanges();
            if (affected > 0)
            {
                transaction.Commit();
                return true;
            }
        }
        catch (Exception ex)
        {
            //TODO Log Exception Handling message                      
        }
        transaction.Rollback();
        return false;
    }
    public async Task<bool> SaveAsync()
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var affected = await _dbContext.SaveChangesAsync();
            if (affected > 0)
            {
                await transaction.CommitAsync();
                return true;
            }

        }
        catch (Exception ex)
        {
            //TODO Log Exception Handling message                      
        }
        await transaction.RollbackAsync();
        return false;
    }

    public void Dispose()
    {
        if(_disposed) return;
        _dbContext.Dispose();
        GC.SuppressFinalize(this);
        _disposed = true;
    }
}