using ECom.Application.Manager;
using ECom.Application.Validators;
using ECom.Domain.DTOs.AdminDTOs;
using ECom.Domain.DTOs.UserDTOs;
using ECom.Domain.Lib;

namespace ECom.Application.DependencyResolvers
{
    public static class BusinessDependencyResolver
    {
        

        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
            //services.AddScoped<DbContext, EComDbContext>();
            services.AddDbContext<EComDbContext>();
            services.AddScoped<IOptionService, OptionService>();
            services.AddScoped<ICompanyInformationService, CompanyInformationService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<ISliderService, SliderService>();
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICollectionService, CollectionService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IFavoriteProductService, FavoriteProductService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDebugService, DebugService>();

            return services;
        }

        public static IServiceCollection AddDataBaseAccessServices(this IServiceCollection services)
        {
            //services.AddScoped<IEntityRepository<Address>, AddressDal>();
            //services.AddScoped<IEntityRepository<Admin>, AdminDal>();
            //services.AddScoped<IEntityRepository<AdminLog>, AdminLogDal>();
            //services.AddScoped<IEntityRepository<Announcement>, AnnouncementDal>();
            //services.AddScoped<IEntityRepository<CargoOption>, CargoOptionDal>();
            //services.AddScoped<IEntityRepository<Cart>, CartDal>();
            //services.AddScoped<IEntityRepository<Category>, CategoryDAL>();
            //services.AddScoped<IEntityRepository<CategoryDiscount>, CategoryDiscountDal>();
            //services.AddScoped<IEntityRepository<Collection>, CollectionDal>();
            //services.AddScoped<IEntityRepository<CollectionProduct>, CollectionProductDal>();
            //services.AddScoped<IEntityRepository<CompanyInformation>, CompanyInformationDal>();
            //services.AddScoped<IEntityRepository<DiscountCoupon>, DiscountCouponDal>();
            //services.AddScoped<IEntityRepository<DiscountNotify>, DiscountNotifyDal>();
            //services.AddScoped<IEntityRepository<EmailVerifyToken>, EmailVerifyTokenDal>();
            //services.AddScoped<IEntityRepository<FavoriteProduct>, FavoriteProductDal>();
            //services.AddScoped<IEntityRepository<Image>, ImageDal>();
            //services.AddScoped<IEntityRepository<Option>, OptionDal>();
            //services.AddScoped<IEntityRepository<Order>, OrderDal>();
            //services.AddScoped<IEntityRepository<PasswordResetToken>, PasswordResetTokenDal>();
            //services.AddScoped<IEntityRepository<PaymentOption>, PaymentOptionDal>();
            //services.AddScoped<IEntityRepository<Permission>, PermissionDal>();
            //services.AddScoped<IEntityRepository<Product>, ProductDal>();
            //services.AddScoped<IEntityRepository<ProductComment>, ProductCommentDal>();
            //services.AddScoped<IEntityRepository<ProductDetail>, ProductDetailDal>();
            //services.AddScoped<IEntityRepository<ProductImage>, ProductImageDal>();
            //services.AddScoped<IEntityRepository<ProductVariant>, ProductVariantDal>();
            //services.AddScoped<IEntityRepository<Role>, RoleDal>();
            //services.AddScoped<IEntityRepository<RolePermission>, RolePermissionDal>();
            //services.AddScoped<IEntityRepository<SecurityLog>, SecurityLogDal>();
            //services.AddScoped<IEntityRepository<Slider>, SliderDal>();
            //services.AddScoped<IEntityRepository<SmtpOption>, SmtpOptionDal>();
            //services.AddScoped<IEntityRepository<SubCategory>, SubCategoryDal>();
            //services.AddScoped<IEntityRepository<User>, UserDal>();
            //services.AddScoped<IEntityRepository<UserLog>, UserLogDal>();
            //services.AddScoped<IEntityRepository<ProductSubCategory>, ProductSubCategoryDal>();
            //services.AddScoped<IEntityRepository<StockChange>, StockChangeDal>();
            //services.AddScoped<IEntityRepository<Supplier>, SupplierDal>();
            //services.AddScoped<IEntityRepository<ProductShowCase>, ProductShowCaseDal>();
            //services.AddScoped<IEntityRepository<ShowCaseImage>, ShowCaseImageDal>();
            return services;
        }

        public static IServiceCollection AddBusinessValidators(this IServiceCollection services)
        {

            services.AddScoped<IValidationService, ValidationService>();

            services.AddTransient<IValidator<LoginRequest>, LoginValidator>();
            services.AddTransient<IValidator<RegisterUserRequest>, RegisterValidator>();
            services.AddTransient<IValidator<AddAdminRequest>, AddAdminRequestValidator>();
            services.AddTransient<IValidator<ChangePasswordRequest>, ChangePasswordRequestValidator>();
            services.AddTransient<IValidator<UpdateAdminAccountRequest>, UpdateAdminAccountRequestValidator>();
            return services;
        }

        public static IServiceCollection AddAutoMapperConfigured(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            return services;
        }
        public static IServiceCollection AddBusinessAuthenticators(this IServiceCollection services)
        {
            services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
            services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();
            return services;
        }
    }
}
