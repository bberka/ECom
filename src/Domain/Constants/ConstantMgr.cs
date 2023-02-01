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
	public class ConstantMgr
	{
		public const int UsernameMinLength = 3;
		public const int UsernameMaxLength = 32;


		public const int PasswordMinLength = 3;
		public const int PasswordMaxLength = 32;
		public const int EmailMaxLength = 255;


	}
}
