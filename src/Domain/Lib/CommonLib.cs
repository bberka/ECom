using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Lib
{
	public static class CommonLib
	{
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
