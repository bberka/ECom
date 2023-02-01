using EasMe;
using ECom.Application.BaseManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Application.Manager
{
	public class JwtAuthenticator
	{

		private JwtAuthenticator() 
		{
			var option = OptionMgr.This.GetSingle();
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
