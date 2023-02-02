using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Infrastructure.DependencyResolvers.AspNetCore
{
	public static class ServiceProviderProxy
	{

		private static IServiceProvider? _serviceProvider;
		public static void Initialize(this IServiceProvider serviceProvider)
		{
			if (serviceProvider != null) throw new Exception("Already initialized");
			_serviceProvider = serviceProvider;
		}
		public static IServiceProvider Get()
		{
			if (_serviceProvider is null)
			{
				throw new InvalidOperationException("Service provider is not initialized");
			}
			return _serviceProvider;
		}
		public static T GetService<T>()  
			where T : class
		{
			if(_serviceProvider is null)
				throw new InvalidOperationException("Service provider is not initialized");

			return (T)_serviceProvider.GetService(typeof(T)) ?? throw new Exception("Invalid Service: " + nameof(T));
		}
	}

}
