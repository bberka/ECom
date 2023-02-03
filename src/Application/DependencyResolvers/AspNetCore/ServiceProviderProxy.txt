using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.DependencyResolvers.AspNetCore
{
	internal class ServiceProviderProxy
	{
		private ServiceProviderProxy() { }
		public static ServiceProviderProxy This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static ServiceProviderProxy? Instance;
		private IServiceProvider? _serviceProvider;
		public void Load(IServiceProvider serviceProvider)
		{
			if (_serviceProvider != null) throw new Exception("Already initialized");
			_serviceProvider = serviceProvider;
		}
		public IServiceProvider Get()
		{
			if (_serviceProvider is null)
			{
				throw new InvalidOperationException("Service provider is not initialized");
			}
			return _serviceProvider;
		}
		public T GetService<T>()  
			where T : class
		{
			if(_serviceProvider is null)
				throw new InvalidOperationException("Service provider is not initialized");

			return (T)_serviceProvider.GetService(typeof(T)) ?? throw new Exception("Invalid Service: " + nameof(T));
		}
	}

}
