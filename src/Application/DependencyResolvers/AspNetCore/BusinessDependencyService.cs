using ECom.Application.Manager;
using ECom.Application.Validators;
using ECom.Infrastructure;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Application.DependencyResolvers.AspNetCore
{
	public static class BusinessDependencyService
	{
		public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
		{
			services.AddSingleton<IOptionService, OptionService>();
			services.AddSingleton<IJwtOptionService, JwtOptionService>();
			services.AddScoped<ISmtpOptionService, SmtpOptionService>();
			services.AddScoped<IPaymentOptionService, PaymentOptionService>();
			services.AddScoped<ICompanyInformationService, CompanyInformationService>();

			services.AddScoped<IPermissionService, PermissionService>();
			services.AddScoped<IRoleBindService, RoleBindService>();
			services.AddScoped<IRoleService, RoleService>();

			services.AddScoped<IImageService, ImageService>();
			services.AddScoped<ILanguageService, LanguageService>();

			services.AddScoped<IAnnouncementService, AnnouncementService>();
			services.AddScoped<ISliderService, SliderService>();

			services.AddScoped<IUserLogService, UserLogService>();
			services.AddScoped<ISecurityLogService, SecurityLogService>();
			services.AddScoped<IAdminLogService, AdminLogService>();


			services.AddTransient<IValidator<LoginModel>, LoginValidator>();
			services.AddTransient<IValidator<RegisterModel>, RegisterValidator>();
			services.AddTransient<IValidator<User>, UserValidator>();
			services.AddTransient<IValidator<Admin>, AdminValidator>();

			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAdminService, AdminService>();

			services.AddScoped<ISubCategoryService, SubCategoryService>();
			services.AddScoped<ICategoryService, CategoryService>();


			services.AddScoped<IAddressService, AddressService>();
			services.AddScoped<ICargoOptionService, CargoOptionService>();

			services.AddScoped<ICategoryDiscountService, CategoryDiscountService>();
			services.AddScoped<IDiscountCouponService, DiscountCouponService>();
			services.AddScoped<IDiscountNotifyService, DiscountNotifyService>();

			services.AddScoped<IEmailVerifyTokenService, EmailVerifyTokenService>();
			services.AddScoped<IPasswordResetTokenService, PasswordResetTokenService>();


			services.AddScoped<IOrderService, OrderService>();

			services.AddScoped<ICollectionProductService, CollectionProductService>();
			services.AddScoped<ICollectionService, CollectionService>();

			services.AddScoped<ICartService, CartService>();

			services.AddScoped<IFavoriteProductService, FavoriteProductService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductCommentImageBindService, ProductCommentImageBindService>();
			services.AddScoped<IProductCommentService, ProductCommentService>();
			services.AddScoped<IProductDetailService, ProductDetailService>();
			services.AddScoped<IProductImageBindService, ProductImageBindService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductVariantService, ProductVariantService>();


			services.AddScoped<IAdminJwtAuthenticator, AdminJwtAuthenticator>();
			services.AddScoped<IUserJwtAuthenticator, UserJwtAuthenticator>();



			services.AddScoped<DbContext, EComDbContext>();
			return services;
		}

	}
}
