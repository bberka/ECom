using Domain.Interfaces;
using Domain.LOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Localization
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
		
		private static readonly string _json = "en.json";
		private static readonly string _path = Path.Combine("LOC", _json);
	
		public string Get(string key)
		{
			return EN.ResourceManager.GetString(key) ?? key;
		}
	}
}
