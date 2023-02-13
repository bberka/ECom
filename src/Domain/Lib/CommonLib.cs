using Newtonsoft.Json;

namespace ECom.Domain.Lib
{
	public static class CommonLib
	{
        public static string SerializeJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                
            });
        }
        public static bool IsCultureValid(string cultureName)
        {
            if(cultureName == null) return false;
            if(cultureName.Length < 2) return false;
            if(cultureName.Length > 4) return false;
            if (!GetCultureNames().Contains(cultureName)) return false;
            return true;
        }

        public static string[] GetCultureNames()
        {
            return Enum.GetNames<LanguageType>();
        }
        public static string[] GetAdminOperationTypes()
        {
            return Enum.GetNames<AdminOperationType>();
        }

        public static string[] GetCurrencyTypes()
        {
            return Enum.GetNames<CurrencyType>();
        }
    }
}
