using ECom.Domain.Entities;
using ECom.Infrastructure.Abstract;
using ECom.Infrastructure.Repository;
using Serilog;

namespace ECom.Infrastructure;

public class UnitOfWork : UnitOfWorkBase<EComDbContext>,IUnitOfWork
{
  public UnitOfWork(EComDbContext comDbContext) : base(comDbContext) {

  }

  private IRepository<Address>? _addressRepository;
  public IRepository<Address> AddressRepository 
  {
    get {
      _addressRepository??= new AddressRepository(DbContext);
      return _addressRepository;
    }
  }
  private IRepository<Admin>? _adminRepository;
  public IRepository<Admin> AdminRepository {
    get {   
      _adminRepository ??= new AdminRepository(DbContext);
      return _adminRepository;
    }
  }

  private IRepository<AdminLog>? _adminLogRepository;
  public IRepository<AdminLog> AdminLogRepository {
    get {
      _adminLogRepository ??= new AdminLogRepository(DbContext);
      return _adminLogRepository;
    }
  }

  private IRepository<Announcement>? _announcementRepository;
  public IRepository<Announcement> AnnouncementRepository {
    get {
      _announcementRepository ??= new AnnouncementRepository(DbContext);
      return _announcementRepository;
    }
  }


  private IRepository<CargoOption>? _cargoOptionRepository;

  public IRepository<CargoOption> CargoOptionRepository {
    get {
      _cargoOptionRepository ??= new CargoOptionRepository(DbContext);
      return _cargoOptionRepository;
    }

  }
  private IRepository<Cart>? _cartRepository;

  public IRepository<Cart> CartRepository {
    get {
      _cartRepository ??= new CartRepository(DbContext);
      return _cartRepository;
    }
  }

  private IRepository<Category>? _categoryRepository;

  public IRepository<Category> CategoryRepository {
    get {
      _categoryRepository ??= new CategoryRepository(DbContext);
      return _categoryRepository;
    }
  }
  private IRepository<CategoryDiscount>? _categoryDiscountRepository;

  public IRepository<CategoryDiscount> CategoryDiscountRepository {
    get {
      _categoryDiscountRepository ??= new CategoryDiscountRepository(DbContext);
      return _categoryDiscountRepository;
    }
  }


  private IRepository<Collection>? _collectionRepository;

  public IRepository<Collection> CollectionRepository {
    get {
      _collectionRepository ??= new CollectionRepository(DbContext);
      return _collectionRepository;
    }
  }


  private IRepository<CollectionProduct>? _collectionProductRepository;

  public IRepository<CollectionProduct> CollectionProductRepository {
    get {
      _collectionProductRepository ??= new CollectionProductRepository(DbContext);
      return _collectionProductRepository;
    }
  }


  private IRepository<CompanyInformation>? _companyInformationRepository;

  public IRepository<CompanyInformation> CompanyInformationRepository {
    get {
      _companyInformationRepository ??= new CompanyInformationRepository(DbContext);
      return _companyInformationRepository;
    }
  }


  private IRepository<DiscountCoupon>? _discountCouponRepository;

  public IRepository<DiscountCoupon> DiscountCouponRepository {
    get {
      _discountCouponRepository ??= new DiscountCouponRepository(DbContext);
      return _discountCouponRepository;
    }
  }


  private IRepository<DiscountNotify>? _discountNotifyRepository;

  public IRepository<DiscountNotify> DiscountNotifyRepository {
    get {
      _discountNotifyRepository ??= new DiscountNotifyRepository(DbContext);
      return _discountNotifyRepository;
    }
  }


  private IRepository<EmailVerifyToken>? _emailVerifyTokenRepository;

  public IRepository<EmailVerifyToken> EmailVerifyTokenRepository {
    get {
      _emailVerifyTokenRepository ??= new EmailVerifyTokenRepository(DbContext);
      return _emailVerifyTokenRepository;
    }
  }


  private IRepository<FavoriteProduct>? _favoriteProductRepository;

  public IRepository<FavoriteProduct> FavoriteProductRepository {
    get {
      _favoriteProductRepository ??= new FavoriteProductRepository(DbContext);
      return _favoriteProductRepository;
    }
  }


  private IRepository<Image>? _imageRepository;

  public IRepository<Image> ImageRepository {
    get {
      _imageRepository ??= new ImageRepository(DbContext);
      return _imageRepository;
    }
  }


  private IRepository<Option>? _optionRepository;

  public IRepository<Option> OptionRepository {
    get {
      _optionRepository ??= new OptionRepository(DbContext);
      return _optionRepository;
    }
  }



  private IRepository<Order>? _orderRepository;

  public IRepository<Order> OrderRepository {
    get {
      _orderRepository ??= new OrderRepository(DbContext);
      return _orderRepository;
    }
  }


  private IRepository<PasswordResetToken>? _passwordResetTokenRepository;

  public IRepository<PasswordResetToken> PasswordResetTokenRepository {
    get {
      _passwordResetTokenRepository ??= new PasswordResetTokenRepository(DbContext);
      return _passwordResetTokenRepository;
    }
  }


  private IRepository<PaymentOption>? _paymentOptionRepository;

  public IRepository<PaymentOption> PaymentOptionRepository {
    get {
      _paymentOptionRepository ??= new PaymentOptionRepository(DbContext);
      return _paymentOptionRepository;
    }
  }


  private IRepository<Permission>? _permissionRepository;

  public IRepository<Permission> PermissionRepository {
    get {
      _permissionRepository ??= new PermissionRepository(DbContext);
      return _permissionRepository;
    }
  }

  private IRepository<Product>? _productRepository;

  public IRepository<Product> ProductRepository {
    get {
      _productRepository ??= new ProductRepository(DbContext);
      return _productRepository;
    }
  }


  private IRepository<ProductComment>? _productCommentRepository;

  public IRepository<ProductComment> ProductCommentRepository {
    get {
      _productCommentRepository ??= new ProductCommentRepository(DbContext);
      return _productCommentRepository;
    }
  }


  private IRepository<ProductDetail>? _productDetailRepository;

  public IRepository<ProductDetail> ProductDetailRepository {
    get {
      _productDetailRepository ??= new ProductDetailRepository(DbContext);
      return _productDetailRepository;
    }
  }


  private IRepository<ShowCase>? _showCaseRepository;

  public IRepository<ShowCase> ShowCaseRepository {
    get {
      _showCaseRepository ??= new ShowCaseRepository(DbContext);
      return _showCaseRepository;
    }
  }


  private IRepository<ProductCategory>? _productCategoryRepository;

  public IRepository<ProductCategory> ProductCategoryRepository {
    get {
      _productCategoryRepository ??= new ProductCategoryRepository(DbContext);
      return _productCategoryRepository;
    }
  }


  private IRepository<ProductVariant>? _productVariantRepository;

  public IRepository<ProductVariant> ProductVariantRepository {
    get {
      _productVariantRepository ??= new ProductVariantRepository(DbContext);
      return _productVariantRepository;
    }
  }


  private IRepository<Role>? _roleRepository;

  public IRepository<Role> RoleRepository {
    get {
      _roleRepository ??= new RoleRepository(DbContext);
      return _roleRepository;
    }
  }


  private IRepository<PermissionRole>? _permissionRoleRepository;

  public IRepository<PermissionRole> PermissionRoleRepository {
    get {
      _permissionRoleRepository ??= new PermissionRoleRepository(DbContext);
      return _permissionRoleRepository;
    }
  }


  private IRepository<SecurityLog>? _securityLogRepository;

  public IRepository<SecurityLog> SecurityLogRepository {
    get {
      _securityLogRepository ??= new SecurityLogRepository(DbContext);
      return _securityLogRepository;
    }
  }

  private IRepository<Slider>? _sliderRepository;

  public IRepository<Slider> SliderRepository {
    get {
      _sliderRepository ??= new SliderRepository(DbContext);
      return _sliderRepository;
    }
  }


  private IRepository<SmtpOption>? _smtpOptionRepository;

  public IRepository<SmtpOption> SmtpOptionRepository {
    get {
      _smtpOptionRepository ??= new SmtpOptionRepository(DbContext);
      return _smtpOptionRepository;
    }
  }

  private IRepository<StockChange>? _stockChangeRepository;

  public IRepository<StockChange> StockChangeRepository {
    get {
      _stockChangeRepository ??= new StockChangeRepository(DbContext);
      return _stockChangeRepository;
    }
  }


  private IRepository<Supplier>? _supplierRepository;

  public IRepository<Supplier> SupplierRepository {
    get {
      _supplierRepository ??= new SupplierRepository(DbContext);
      return _supplierRepository;
    }
  }


  private IRepository<User>? _userRepository;

  public IRepository<User> UserRepository {
    get {
      _userRepository ??= new UserRepository(DbContext);
      return _userRepository;
    }
  }

}