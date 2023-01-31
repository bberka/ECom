namespace ECom.Domain.Localization
{
	public class EN_Localization : ILocalization
	{
		private EN_Localization()
		{

		}
		public static EN_Localization This
		{
			get
			{
				_singleton ??= new EN_Localization();
				return _singleton;
			}
		}
		private static EN_Localization? _singleton = null;
		
	
		public string Get(string key)
		{

			return Resources.Resource.ResourceManager.GetString(key) ?? key;
		}
	}
}
