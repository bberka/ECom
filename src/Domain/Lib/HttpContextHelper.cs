using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Domain.Lib
{
	public static class HttpContextHelper
	{
		private readonly static HttpContextAccessor Accessor = new();
		public static HttpContext? Current
		{
			get
			{
				if (Accessor is null) return null;
				return Accessor.HttpContext;
			}
		}

	}
}
