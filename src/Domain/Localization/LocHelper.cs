using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Localization
{
    public static class LocHelper
    {
        public static string Get(string key)
        {
            return Resources.Resource.ResourceManager.GetString(key) ?? key;
        }
    }
}
