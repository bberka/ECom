using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasMe;
using EasMe.Extensions;

namespace ECom.Domain.Constants
{
	public static class ConstantMgr
	{
		public const byte StringMinLength = 3;

		public const byte NameMaxLength = 64;
		public const byte EmailMaxLength = 255;
		public const byte PasswordMaxLength = 32;
		public const byte TitleMaxLength = 32;
		public const byte PhoneNumberMaxLength = 32;

		public const string VERSION = "v0.0.1";

		public static bool IsDebug()
		{
#if DEBUG
            return true;
#endif
			return false;
        }
    }
}
