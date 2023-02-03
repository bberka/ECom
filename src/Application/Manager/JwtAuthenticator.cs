


namespace ECom.Application.Manager
{
	public class JwtAuthenticator
	{

		private JwtAuthenticator() 
		{
			var jwtOption = ServiceProviderProxy.This.GetService<IJwtOptionService>().GetFromCache();
			Authenticator = new(jwtOption.Secret);
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
