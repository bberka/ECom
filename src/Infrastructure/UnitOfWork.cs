using ECom.Infrastructure.Repository;

namespace ECom.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
  private readonly EComDbContext _dbContext;
  private bool _disposed;

  public UnitOfWork() {
    _disposed = false;
    _dbContext = new EComDbContext();
    AddressRepository = new AddressRepository(_dbContext);
    AdminRepository = new AdminRepository(_dbContext);
    AdminLogRepository = new AdminLogRepository(_dbContext);
    AnnouncementRepository = new AnnouncementRepository(_dbContext);
    CargoOptionRepository = new CargoOptionRepository(_dbContext);
    CartRepository = new CartRepository(_dbContext);
    CategoryRepository = new CategoryRepository(_dbContext);
    CategoryDiscountRepository = new CategoryDiscountRepository(_dbContext);
    CollectionRepository = new CollectionRepository(_dbContext);
    CollectionProductRepository = new CollectionProductRepository(_dbContext);
    CompanyInformationRepository = new CompanyInformationRepository(_dbContext);
    DiscountCouponRepository = new DiscountCouponRepository(_dbContext);
    DiscountNotifyRepository = new DiscountNotifyRepository(_dbContext);
    EmailVerifyTokenRepository = new EmailVerifyTokenRepository(_dbContext);
    FavoriteProductRepository = new FavoriteProductRepository(_dbContext);
    ImageRepository = new ImageRepository(_dbContext);
    OptionRepository = new OptionRepository(_dbContext);
    OrderRepository = new OrderRepository(_dbContext);
    PasswordResetTokenRepository = new PasswordResetTokenRepository(_dbContext);
    PaymentOptionRepository = new PaymentOptionRepository(_dbContext);
    PermissionRepository = new PermissionRepository(_dbContext);
    ProductRepository = new ProductRepository(_dbContext);
    ProductCommentRepository = new ProductCommentRepository(_dbContext);
    ProductDetailRepository = new ProductDetailRepository(_dbContext);
    ProductShowCaseRepository = new ProductShowCaseRepository(_dbContext);
    ProductSubCategoryRepository = new ProductSubCategoryRepository(_dbContext);
    ProductVariantRepository = new ProductVariantRepository(_dbContext);
    RoleRepository = new RoleRepository(_dbContext);
    PermissionRoleRepository = new PermissionRoleRepository(_dbContext);
    SecurityLogRepository = new SecurityLogRepository(_dbContext);
    ShowCaseImageRepository = new ShowCaseImageRepository(_dbContext);
    SliderRepository = new SliderRepository(_dbContext);
    SmtpOptionRepository = new SmtpOptionRepository(_dbContext);
    StockChangeRepository = new StockChangeRepository(_dbContext);
    SubCategoryRepository = new SubCategoryRepository(_dbContext);
    SupplierRepository = new SupplierRepository(_dbContext);
    UserRepository = new UserRepository(_dbContext);
    UserLogRepository = new UserLogRepository(_dbContext);
  }

  public IGenericRepository<Address> AddressRepository { get; }
  public IGenericRepository<Admin> AdminRepository { get; }
  public IGenericRepository<AdminLog> AdminLogRepository { get; }
  public IGenericRepository<Announcement> AnnouncementRepository { get; }
  public IGenericRepository<CargoOption> CargoOptionRepository { get; }
  public IGenericRepository<Cart> CartRepository { get; }
  public IGenericRepository<Category> CategoryRepository { get; }
  public IGenericRepository<CategoryDiscount> CategoryDiscountRepository { get; }
  public IGenericRepository<Collection> CollectionRepository { get; }
  public IGenericRepository<CollectionProduct> CollectionProductRepository { get; }
  public IGenericRepository<CompanyInformation> CompanyInformationRepository { get; }
  public IGenericRepository<DiscountCoupon> DiscountCouponRepository { get; }
  public IGenericRepository<DiscountNotify> DiscountNotifyRepository { get; }
  public IGenericRepository<EmailVerifyToken> EmailVerifyTokenRepository { get; }
  public IGenericRepository<FavoriteProduct> FavoriteProductRepository { get; }
  public IGenericRepository<Image> ImageRepository { get; }
  public IGenericRepository<Option> OptionRepository { get; }
  public IGenericRepository<Order> OrderRepository { get; }
  public IGenericRepository<PasswordResetToken> PasswordResetTokenRepository { get; }
  public IGenericRepository<PaymentOption> PaymentOptionRepository { get; }
  public IGenericRepository<Permission> PermissionRepository { get; }
  public IGenericRepository<Product> ProductRepository { get; }
  public IGenericRepository<ProductComment> ProductCommentRepository { get; }
  public IGenericRepository<ProductDetail> ProductDetailRepository { get; }
  public IGenericRepository<ProductShowCase> ProductShowCaseRepository { get; }
  public IGenericRepository<ProductSubCategory> ProductSubCategoryRepository { get; }
  public IGenericRepository<ProductVariant> ProductVariantRepository { get; }
  public IGenericRepository<Role> RoleRepository { get; }
  public IGenericRepository<PermissionRole> PermissionRoleRepository { get; }
  public IGenericRepository<SecurityLog> SecurityLogRepository { get; }
  public IGenericRepository<ShowCaseImage> ShowCaseImageRepository { get; }
  public IGenericRepository<Slider> SliderRepository { get; }
  public IGenericRepository<SmtpOption> SmtpOptionRepository { get; }
  public IGenericRepository<StockChange> StockChangeRepository { get; }
  public IGenericRepository<SubCategory> SubCategoryRepository { get; }
  public IGenericRepository<Supplier> SupplierRepository { get; }
  public IGenericRepository<User> UserRepository { get; }
  public IGenericRepository<UserLog> UserLogRepository { get; }


  public bool Save() {
    using var transaction = _dbContext.Database.BeginTransaction();
    try {
      var affected = _dbContext.SaveChanges();
      if (affected > 0) {
        transaction.Commit();
        return true;
      }
    }
    catch (Exception ex) {
      //TODO Log Exception Handling message                      
    }

    transaction.Rollback();
    return false;
  }

  public async Task<bool> SaveAsync() {
    await using var transaction = await _dbContext.Database.BeginTransactionAsync();
    try {
      var affected = await _dbContext.SaveChangesAsync();
      if (affected > 0) {
        await transaction.CommitAsync();
        return true;
      }
    }
    catch (Exception ex) {
      //TODO Log Exception Handling message                      
    }

    await transaction.RollbackAsync();
    return false;
  }

  public void Dispose() {
    if (_disposed) return;
    _dbContext.Dispose();
    GC.SuppressFinalize(this);
    _disposed = true;
  }
}