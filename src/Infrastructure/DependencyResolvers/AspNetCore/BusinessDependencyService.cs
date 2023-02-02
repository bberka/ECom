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
			services.AddSingleton<IOptionService, OptionService>();
			services.BuildServiceProvider().Initialize();
			services.AddScoped<DbContext, EComDbContext>();
			return services;
		}

	}
}
