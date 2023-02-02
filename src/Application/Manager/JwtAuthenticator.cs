namespace ECom.Application.Manager
{
	public class JwtAuthenticator
	{

		private JwtAuthenticator() 
		{
			var option = OptionDal.This.GetSingle();
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
