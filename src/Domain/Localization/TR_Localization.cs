namespace ECom.Domain.Localization
{
	public class TR_Localization : ILocalization
	{
		private TR_Localization()
		{

		}
		public static TR_Localization This
		{
			get
			{
				_singleton ??= new TR_Localization();
				return _singleton;
			}
		}
		private static TR_Localization? _singleton = null;
		public string Get(string key)
		{
			throw new NotImplementedException();
		}
	}
}
