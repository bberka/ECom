using ECom.Application.Manager;
using ECom.Application.Validators;
using ECom.Domain.ApiModels.Request;
using ECom.Domain.Interfaces;
using ECom.Infrastructure;
using ECom.Infrastructure.DataAccess;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Application.DependencyResolvers.AspNetCore
{
    public static class BusinessDependencyService
	{
		public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
		{
			//Data Access Layer
			services.AddScoped<IEfEntityRepository<Address>, AddressDal>();
			services.AddScoped<IEfEntityRepository<Admin>, AdminDal>();
			services.AddScoped<IEfEntityRepository<AdminLog>, AdminLogDal>();
			services.AddScoped<IEfEntityRepository<Announcement>, AnnouncementDal>();
			services.AddScoped<IEfEntityRepository<CargoOption>, CargoOptionDal>();
			services.AddScoped<IEfEntityRepository<Cart>, CartDal>();
			services.AddScoped<IEfEntityRepository<Category>, CategoryDAL>();
			services.AddScoped<IEfEntityRepository<CategoryDiscount>, CategoryDiscountDAL>();
			services.AddScoped<IEfEntityRepository<Collection>, CollectionDAL>();
			services.AddScoped<IEfEntityRepository<CollectionProduct>, CollectionProductDAL>();
			services.AddScoped<IEfEntityRepository<CompanyInformation>, CompanyInformationDAL>();
			services.AddScoped<IEfEntityRepository<DiscountCoupon>, DiscountCouponDAL>();
			services.AddScoped<IEfEntityRepository<DiscountNotify>, DiscountNotifyDAL>();
			services.AddScoped<IEfEntityRepository<EmailVerifyToken>, EmailVerifyTokenDAL>();
			services.AddScoped<IEfEntityRepository<FavoriteProduct>, FavoriteProductDAL>();
			services.AddScoped<IEfEntityRepository<Image>, ImageDal>();
			services.AddScoped<IEfEntityRepository<Language>, LanguageDAL>();
			services.AddScoped<IEfEntityRepository<Option>, OptionDAL>();
			services.AddScoped<IEfEntityRepository<Order>, OrderDAL>();
			services.AddScoped<IEfEntityRepository<PasswordResetToken>, PasswordResetTokenDAL>();
			services.AddScoped<IEfEntityRepository<PaymentOption>, PaymentOptionDAL>();
			services.AddScoped<IEfEntityRepository<Permission>, PermissionDAL>();
			services.AddScoped<IEfEntityRepository<Product>, ProductDAL>();
			services.AddScoped<IEfEntityRepository<ProductComment>, ProductCommentDAL>();
			services.AddScoped<IEfEntityRepository<ProductCommentImage>, ProductCommentImageDAL>();
			services.AddScoped<IEfEntityRepository<ProductDetail>, ProductDetailDAL>();
			services.AddScoped<IEfEntityRepository<ProductImage>, ProductImageDAL>();
			services.AddScoped<IEfEntityRepository<ProductVariant>, ProductVariantDAL>();
			services.AddScoped<IEfEntityRepository<Role>, RoleDAL>();
			services.AddScoped<IEfEntityRepository<RolePermission>, RolePermissionDAL>();
			services.AddScoped<IEfEntityRepository<SecurityLog>, SecurityLogDAL>();
			services.AddScoped<IEfEntityRepository<Slider>, SliderDAL>();
			services.AddScoped<IEfEntityRepository<SmtpOption>, SmtpOptionDAL>();
			services.AddScoped<IEfEntityRepository<SubCategory>, SubCategoryDAL>();
			services.AddScoped<IEfEntityRepository<User>, UserDAL>();
			services.AddScoped<IEfEntityRepository<UserLog>, UserLogDAL>();
			services.AddScoped<IEfEntityRepository<ProductSubCategory>, ProductSubCategoryDAL>();
			services.AddScoped<IEfEntityRepository<ImageLanguage>, ImageLanguageDAL>();
			services.AddScoped<IEfEntityRepository<StockChange>, StockChangeDAL>();
			services.AddScoped<IEfEntityRepository<Supplier>, SupplierDAL>();
			services.AddScoped<IEfEntityRepository<ProductShowCase>, ProductShowCaseDAL>();
			services.AddScoped<IEfEntityRepository<ShowCaseImage>, ShowCaseImageDAL>();


			//Business Logic
			services.AddScoped<IOptionService, OptionService>();
			services.AddScoped<ICompanyInformationService, CompanyInformationService>();
			services.AddScoped<IImageService, ImageService>();
			services.AddScoped<ILanguageService, LanguageService>();
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

			//JWT AUTH
			services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
			services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();

			//AUTH

			//Validator
			services.AddTransient<IValidator<LoginRequestModel>, LoginValidator>();
			services.AddTransient<IValidator<RegisterRequestModel>, RegisterValidator>();
			services.AddTransient<IValidator<User>, UserValidator>();
			services.AddTransient<IValidator<Admin>, AdminValidator>();

			services.AddScoped<IValidationDbService, ValidationDbService>();

			//DB
			services.AddScoped<DbContext, EComDbContext>();
			return services;
		}

	}
}
