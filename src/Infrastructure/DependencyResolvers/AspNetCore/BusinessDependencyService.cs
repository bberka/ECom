using ECom.Infrastructure;
using ECom.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.DependencyResolvers.AspNetCore
{
	public static class BusinessDependencyService
	{
		public static IServiceCollection AddBusinessDependencies(this IServiceCollection services)
		{
			services.AddScoped<IAnnouncementService, AnnouncementService>();
			services.AddScoped<IAdminService, AdminService>();
			services.AddScoped<ICartService, CartService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAddressService, AddressService>();
			services.AddScoped<IAdminLogService, AdminLogService>();
			services.AddScoped<ICargoOptionService, CargoOptionService>();
			services.AddScoped<ICategoryDiscountService, CategoryDiscountService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ICollectionProductService, CollectionProductService>();
			services.AddScoped<ICollectionService, CollectionService>();
			services.AddScoped<ICompanyInformationService, CompanyInformationService>();
			services.AddScoped<IDiscountCouponService, DiscountCouponService>();
			services.AddScoped<IDiscountNotifyService, DiscountNotifyService>();
			services.AddScoped<IEmailVerifyTokenService, EmailVerifyTokenService>();
			services.AddScoped<IFavoriteProductService, FavoriteProductService>();
			services.AddScoped<IImageService, ImageService>();
			services.AddScoped<ILanguageService, LanguageService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IPasswordResetTokenService, PasswordResetTokenService>();
			services.AddScoped<IPaymentOptionService, PaymentOptionService>();
			services.AddScoped<IPermissionService, PermissionService>();
			services.AddScoped<IProductCommentImageBindService, ProductCommentImageBindService>();
			services.AddScoped<IProductCommentService, ProductCommentService>();
			services.AddScoped<IProductDetailService, ProductDetailService>();
			services.AddScoped<IProductImageBindService, ProductImageBindService>();
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IProductVariantService, ProductVariantService>();
			services.AddScoped<IRoleBindService, RoleBindService>();
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<ISecurityLogService, SecurityLogService>();
			services.AddScoped<ISliderService, SliderService>();
			services.AddScoped<ISmtpOptionService, SmtpOptionService>();
			services.AddScoped<ISubCategoryService, SubCategoryService>();
			services.AddScoped<IUserLogService, UserLogService>();


			services.AddSingleton<IOptionService, OptionService>();
			services.AddSingleton<IJwtOptionService, JwtOptionService>();

			services.AddScoped<DbContext, EComDbContext>();
			return services;
		}

	}
}
