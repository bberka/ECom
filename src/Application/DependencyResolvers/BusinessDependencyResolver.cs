using ECom.Application.Manager;
using ECom.Application.Validators;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Interfaces;
using ECom.Infrastructure;
using ECom.Infrastructure.DataAccess;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Application.DependencyResolvers
{
    public static class BusinessDependencyResolver
    {
        

        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services)
        {
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

            return services;
        }

        public static IServiceCollection AddBaseDataBaseAccessLayer(this IServiceCollection services)
        {
            services.AddScoped<IEfEntityRepository<Address>, AddressDal>();
            services.AddScoped<IEfEntityRepository<Admin>, AdminDal>();
            services.AddScoped<IEfEntityRepository<AdminLog>, AdminLogDal>();
            services.AddScoped<IEfEntityRepository<Announcement>, AnnouncementDal>();
            services.AddScoped<IEfEntityRepository<CargoOption>, CargoOptionDal>();
            services.AddScoped<IEfEntityRepository<Cart>, CartDal>();
            services.AddScoped<IEfEntityRepository<Category>, CategoryDAL>();
            services.AddScoped<IEfEntityRepository<CategoryDiscount>, CategoryDiscountDal>();
            services.AddScoped<IEfEntityRepository<Collection>, CollectionDal>();
            services.AddScoped<IEfEntityRepository<CollectionProduct>, CollectionProductDal>();
            services.AddScoped<IEfEntityRepository<CompanyInformation>, CompanyInformationDal>();
            services.AddScoped<IEfEntityRepository<DiscountCoupon>, DiscountCouponDal>();
            services.AddScoped<IEfEntityRepository<DiscountNotify>, DiscountNotifyDal>();
            services.AddScoped<IEfEntityRepository<EmailVerifyToken>, EmailVerifyTokenDal>();
            services.AddScoped<IEfEntityRepository<FavoriteProduct>, FavoriteProductDal>();
            services.AddScoped<IEfEntityRepository<Image>, ImageDal>();
            services.AddScoped<IEfEntityRepository<Option>, OptionDal>();
            services.AddScoped<IEfEntityRepository<Order>, OrderDal>();
            services.AddScoped<IEfEntityRepository<PasswordResetToken>, PasswordResetTokenDal>();
            services.AddScoped<IEfEntityRepository<PaymentOption>, PaymentOptionDal>();
            services.AddScoped<IEfEntityRepository<Permission>, PermissionDal>();
            services.AddScoped<IEfEntityRepository<Product>, ProductDal>();
            services.AddScoped<IEfEntityRepository<ProductComment>, ProductCommentDal>();
            services.AddScoped<IEfEntityRepository<ProductCommentImage>, ProductCommentImageDal>();
            services.AddScoped<IEfEntityRepository<ProductDetail>, ProductDetailDal>();
            services.AddScoped<IEfEntityRepository<ProductImage>, ProductImageDal>();
            services.AddScoped<IEfEntityRepository<ProductVariant>, ProductVariantDal>();
            services.AddScoped<IEfEntityRepository<Role>, RoleDal>();
            services.AddScoped<IEfEntityRepository<RolePermission>, RolePermissionDal>();
            services.AddScoped<IEfEntityRepository<SecurityLog>, SecurityLogDal>();
            services.AddScoped<IEfEntityRepository<Slider>, SliderDal>();
            services.AddScoped<IEfEntityRepository<SmtpOption>, SmtpOptionDal>();
            services.AddScoped<IEfEntityRepository<SubCategory>, SubCategoryDal>();
            services.AddScoped<IEfEntityRepository<User>, UserDal>();
            services.AddScoped<IEfEntityRepository<UserLog>, UserLogDal>();
            services.AddScoped<IEfEntityRepository<ProductSubCategory>, ProductSubCategoryDal>();
            services.AddScoped<IEfEntityRepository<StockChange>, StockChangeDal>();
            services.AddScoped<IEfEntityRepository<Supplier>, SupplierDal>();
            services.AddScoped<IEfEntityRepository<ProductShowCase>, ProductShowCaseDal>();
            services.AddScoped<IEfEntityRepository<ShowCaseImage>, ShowCaseImageDal>();

            services.AddScoped<DbContext, EComDbContext>();

            return services;
        }

        public static IServiceCollection AddBusinessValidators(this IServiceCollection services)
        {

            services.AddScoped<IValidationService, ValidationService>();


            services.AddTransient<IValidator<LoginRequestModel>, LoginValidator>();
            services.AddTransient<IValidator<RegisterRequestModel>, RegisterValidator>();
            services.AddTransient<IValidator<AddAdminRequestModel>, AddAdminRequestModelValidator>();
            services.AddTransient<IValidator<ChangePasswordRequestModel>, ChangePasswordRequestModelValidator>();
            services.AddTransient<IValidator<UpdateAdminAccountRequestModel>, UpdateAdminAccountRequestModelValidator>();
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
