using ECom.Infrastructure.DependencyResolvers.AspNetCore;
using ECom.Infrastructure.Services;

namespace ECom.Application.Manager
{
	public class JwtAuthenticator
	{

		private JwtAuthenticator() 
		{
			var optionService = ServiceProviderProxy.GetService<IOptionService>();
			var option = optionService.GetFromCache();
			Authenticator = new(option.JwtSecret);
		}
		public static JwtAuthenticator This
		{
			get
			{
				Instance ??= new();
				return Instance;
			}
		}
		private static JwtAuthenticator? Instance;

		public EasJWT Authenticator { get; private set; }
	}
}
